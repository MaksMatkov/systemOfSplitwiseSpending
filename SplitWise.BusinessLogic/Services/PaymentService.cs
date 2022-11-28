using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using SplitWise.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.BusinessLogic.Services
{
    public class PaymentService : BaseService<Payment>, IPaymentService
    {
        public PaymentService(splitwiseContext _db) : base(_db) { }

        public async Task<Payment> ApprovePaymant(int paymentId)
        {
            var payment = await GetByKeysAsync(paymentId);
            if (payment == null)
                throw new EntityNotFoundException("The Payment cannot be found.", paymentId);

            payment.Confirmed = true;
            await _db.SaveChangesAsync();

            return payment;
        }
    }
}
