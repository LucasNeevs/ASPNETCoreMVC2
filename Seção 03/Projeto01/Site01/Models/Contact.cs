using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site01.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "This is field is required, please fill it on")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is field is required, please fill it on")]
        [MaxLength(80)]
        [EmailAddress(ErrorMessage = "Email need to contain @ and . complements (as .com, .org and others)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is field is required, please fill it on")]
        [MinLength(3)]
        [MaxLength(25)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This is field is required, please fill it on")]
        [MinLength(3)]
        [MaxLength(2000)]
        public string Message { get; set; }
    }
}
