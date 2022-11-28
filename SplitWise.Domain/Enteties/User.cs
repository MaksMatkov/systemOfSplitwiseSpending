using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Enteties
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public IEnumerable<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public IEnumerable<ExpenseHeader> ExpenseHeaders { get; set; } = new List<ExpenseHeader>();
        public IEnumerable<ExpenseList> ExpenseLists { get; set; } = new List<ExpenseList>();
        public IEnumerable<Payment> PaymantFrom { get; set; } = new List<Payment>();
        public IEnumerable<Payment> PaymantTo { get; set; } = new List<Payment>();

    }
}
