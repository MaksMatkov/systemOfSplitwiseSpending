using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Models
{
    public class ExpenseListRequest
    {
        [Required]
        public decimal amount { get; set; }
        [Required]
        public int expenseHeaderId { get; set; }
    }
}
