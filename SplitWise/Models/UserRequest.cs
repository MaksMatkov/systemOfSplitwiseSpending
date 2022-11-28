using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Models
{
    public class UserRequest
    {
        public int id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name length must be between 3 and 30.", MinimumLength = 3)]
        public string name { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Password length must be between 8 and 16.", MinimumLength = 8)]
        public string password { get; set; }
    }
}
