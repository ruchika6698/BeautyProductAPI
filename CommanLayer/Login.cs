using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer
{
    public class Login
    {
        [Required(ErrorMessage = "EmailID Is Required")]
        [RegularExpression("^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "E-mail is not valid")]

        public string EmailId { get; set; }
        //Enter Password
        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression("^.{8,15}$", ErrorMessage = "Password Length should be between 8 to 15")]

        public string Password { get; set; }

    }
}
