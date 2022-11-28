using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Models
{
    public class PaymentRequest
    {
        public int id { get; set; }
        public string description { get; set; }
        [Required]
        public decimal amount { get; set; }
        [Required(ErrorMessage = "Can`t made payment without recipient!")]
        public int toUserId { get; set; }
        [Required(ErrorMessage = "Can`t made payment without group value!")]
        public int groupId { get; set; }
    }
}
