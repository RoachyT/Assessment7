using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Put_me_on_the_list_chief.Models
{
    public class RegistrationModel
    {

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must contain at least 8 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}