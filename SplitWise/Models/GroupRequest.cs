using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Models
{
    public class GroupRequest
    {
        public int id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name length must be between 3 and 30.", MinimumLength = 3)]
        public string name { get; set; }
    }
}
