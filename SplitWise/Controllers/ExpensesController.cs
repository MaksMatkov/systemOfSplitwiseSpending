using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitWise.API.Helpers;
using SplitWise.API.Models;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.Domain.Enteties;
using SplitWise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService _expenseService;
        private readonly IMapper _mapper;

        public ExpensesController(IExpensesService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }

        //return new entity id
        [HttpPost("Header")]
        [Authorize]
        public async Task<int> PostHeader(ExpenseHeaderRequest item)
        {
            var entity = _mapper.Map<ExpenseHeaderRequest, ExpenseHeader>(item);
            entity.UserId = IdentityHelper.GetSub(User);
            return (await _expenseService.AddExpenseHeaderAsync(entity)).Id;
        }

        //return bool
        [HttpPost("HeaderListItem")]
        [Authorize]
        public async Task<bool> PostHeaderListItem(ExpenseListRequest item)
        {
            var entity = _mapper.Map<ExpenseListRequest, ExpenseList>(item);
            entity.UserId = IdentityHelper.GetSub(User);
            await _expenseService.AddExpenseItemOfListAsync(entity);
            return true;
        }

        [HttpGet("Statistic")]
        [Authorize]
        public async Task<CalculatedData> GetStatistic()
        {
            var userId = IdentityHelper.GetSub(User);
            return await _expenseService.GetCalculatedDataAsync(userId);
        }
    }
}
