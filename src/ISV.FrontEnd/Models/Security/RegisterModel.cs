using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ISV.FrontEnd.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = " Incorrect Email format. Correct: example@mail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords mismatch")]
        public string ConfirmPassword { get; set; }
    }
}