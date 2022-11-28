using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Models
{
    public class PaymentResponse
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public decimal amount { get; set; }
        public bool confirmed { get; set; }
    }
}
