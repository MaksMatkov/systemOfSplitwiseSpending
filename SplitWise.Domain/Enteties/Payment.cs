using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Domain.Enteties
{
    public class Payment 
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
        public bool Confirmed { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int GroupId { get; set; }

        public User FromUser { get; set; }
        public User ToUser { get; set; }
        public Group Group { get; set; }
    }
}
