using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Models
{
    public class ExpenseHeaderRequest
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        [Required]
        public int groupId { get; set; }
    }
}
