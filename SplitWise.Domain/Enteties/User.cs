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

        public IEnumerable<UserGroup> UserGroups { get; set; }
        public IEnumerable<ExpenseHeader> ExpenseHeaders { get; set; }
        public IEnumerable<ExpenseList> ExpenseLists { get; set; }
        public IEnumerable<Payment> PaymantFrom { get; set; }
        public IEnumerable<Payment> PaymantTo { get; set; }

    }
}
