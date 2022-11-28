using SplitWise.Domain.Enteties;
using SplitWise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Abstraction
{
    public interface IExpensesService
    {
        public Task<ExpenseHeader> AddExpenseHeaderAsync(ExpenseHeader item);
        public Task<ExpenseList> AddExpenseItemOfListAsync(ExpenseList item);
        public Task<CalculatedData> GetCalculatedDataAsync(int userId, int groupId = 0);
    }
}
