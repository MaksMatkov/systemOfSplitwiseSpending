using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitWise.API.Helpers;
using SplitWise.API.Models;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        [Authorize]
        public async Task<bool> Approve(int id)
        {
            var payment = await _paymentService.GetByKeysAsync(id);
            if (payment == null)
                throw new EntityNotFoundException("Payment Not Found!", id);

            if (payment.ToUserId != IdentityHelper.GetSub(User))
                throw new ForbiddenException("Not Allow!");

            await _paymentService.ApprovePaymant(id);

            return true;
        }

        [HttpPost]
        [Authorize]
        public async Task<PaymentResponse> Post(PaymentRequest _payment)
        {
            var newPayment = _mapper.Map<PaymentRequest, Payment>(_payment);

            //set payment owner value
            newPayment.FromUserId = IdentityHelper.GetSub(User);

            await _paymentService.SaveAsync(newPayment);

            return _mapper.Map<Payment, PaymentResponse>(newPayment);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DataDeleteResponse> Delete(int id)
        {
            var payment = await _paymentService.GetByKeysAsync(id);
            if (payment == null)
                throw new EntityNotFoundException("Payment Not Found!", id);

            if (payment.ToUserId != IdentityHelper.GetSub(User))
                throw new ForbiddenException("Not Allow!");

            await _paymentService.DeleteAsync(payment);

            return new DataDeleteResponse() { ok = true };
        }



    }
}
