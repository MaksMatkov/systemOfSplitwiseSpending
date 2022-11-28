using SplitWise.BusinessLogic.Abstraction;
using SplitWise.Domain.Enteties;
using SplitWise.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    class ExpenseHeaderService : BaseService<ExpenseHeader>, IExpenseHeaderService
    {
        public ExpenseHeaderService(splitwiseContext _db) : base(_db) { }


    }
}
