using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Abstraction
{
    public interface IPaymentService : IBaseServise<Payment>
    {
        public Task<Payment> ApprovePaymant(int paymantId, int toUserId);
        public Task<bool> DeleteAsync(int paymantId, int toUserId);
    }
}
