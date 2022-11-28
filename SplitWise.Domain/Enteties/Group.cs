using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Enteties
{
    public class Group 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public IEnumerable<ExpenseHeader> ExpenseHeaders { get; set; } = new List<ExpenseHeader>();
        public IEnumerable<Payment> PaymantItems { get; set; } = new List<Payment>();
    }
}
