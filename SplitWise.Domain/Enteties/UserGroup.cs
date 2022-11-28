using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Enteties
{
    public class UserGroup
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int GroupId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
