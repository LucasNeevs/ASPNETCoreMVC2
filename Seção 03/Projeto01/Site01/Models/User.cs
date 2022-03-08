using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class User
    {
        [Required(ErrorMessage = "Email field is indispensable")]
        [EmailAddress(ErrorMessage = "Email field is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is indispensable")]
        public string Password { get; set; }
    }
}
