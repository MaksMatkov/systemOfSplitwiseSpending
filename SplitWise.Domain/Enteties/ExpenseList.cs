using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Enteties
{
    public class ExpenseList
    {
        [Key]
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        [Key]
        public int ExpenseHeaderId { get; set; }

        public User User { get; set; }
        public ExpenseHeader ExpenseHeader { get; set; }
    }
}
