using Microsoft.EntityFrameworkCore;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using SplitWise.Domain.Models;
using SplitWise.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    public class ExpensesService : IExpensesService
    {
        protected readonly splitwiseContext _db;
        public ExpensesService(splitwiseContext db)
        {
            _db = db;
        }

        public async Task<ExpenseHeader> AddExpenseHeaderAsync(ExpenseHeader item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            item.Date = DateTime.UtcNow;

            _db.Update<ExpenseHeader>(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<ExpenseList> AddExpenseItemOfListAsync(ExpenseList item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            var expenseHeader = await _db.Set<ExpenseHeader>().FindAsync(item.ExpenseHeaderId);
            if (expenseHeader == null)
                throw new EntityNotFoundException("Expense Header not found.", item.ExpenseHeaderId);

            (expenseHeader.ExpenseList as List<ExpenseList>).Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<CalculatedData> GetCalculatedDataAsync(int userId, int groupId = 0)
        {
            if (groupId == 0)
            {
                var usersExpenseHeaders = await _db.ExpenseHeaders
                    .Where(el => el.UserId == userId)
                    .Include(el => el.ExpenseList)
                    .ToListAsync();

                var recivedPayments = await _db.Paymants.Where(el => el.ToUserId == userId && el.Confirmed).ToListAsync();

                var recivedPaymentsNotConfirmed = await _db.Paymants.Where(el => el.ToUserId == userId && !el.Confirmed).ToListAsync();

                return new CalculatedData()
                {
                    ExpenseAmount = usersExpenseHeaders.Sum(el => el.ExpenseList.Sum(el => el.Amount)),
                    ReciveAmount = recivedPayments != null ? recivedPayments.Sum(el => el.Amount) : 0,
                    NotConfirmedReciveAmount = recivedPaymentsNotConfirmed != null ? recivedPaymentsNotConfirmed.Sum(el => el.Amount) : 0
                };
            }
            else
            {
                var usersExpenseHeaders = await _db.ExpenseHeaders
                    .Where(el => el.UserId == userId && el.GroupId == groupId)
                    .Include(el => el.ExpenseList)
                    .ToListAsync();

                var recivedPayments = await _db.Paymants.Where(el => el.ToUserId == userId && el.GroupId == groupId).ToListAsync();

                var recivedPaymentsNotConfirmed = await _db.Paymants.Where(el => el.ToUserId == userId && !el.Confirmed).ToListAsync();

                return new CalculatedData()
                {
                    ExpenseAmount = usersExpenseHeaders != null ? usersExpenseHeaders.Sum(el => el.ExpenseList.Sum(el => el.Amount)) : 0,
                    ReciveAmount = recivedPayments != null ? recivedPayments.Sum(el => el.Amount) : 0,
                    NotConfirmedReciveAmount = recivedPaymentsNotConfirmed != null ? recivedPaymentsNotConfirmed.Sum(el => el.Amount) : 0
                };
            }
        }


    }

}
