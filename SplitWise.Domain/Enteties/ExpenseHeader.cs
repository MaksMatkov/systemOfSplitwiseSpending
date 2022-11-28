using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Enteties
{
    public class ExpenseHeader
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
        public IEnumerable<ExpenseList> ExpenseList { get; set; }
    }
}
