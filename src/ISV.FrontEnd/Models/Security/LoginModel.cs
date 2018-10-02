using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ISV.FrontEnd.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Required field")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}