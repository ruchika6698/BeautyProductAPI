using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanLayer
{
    [Table("User")]
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Enter First Name
        [Required(ErrorMessage = "User Name Is Required")]
        [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "First Name is not valid")]
        public string FirstName { get; set; }

        //Enter Last Name
        [Required]
        [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "Last Name is not valid")]
        public string LastName { get; set; }
        //Enter UserRole
        [Required(ErrorMessage = "User Role Is Required")]

        [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "User Role is not valid")]

        public string UserRole { get; set; }
        //Enter Email Address
        [Required(ErrorMessage = "EmailID Is Required")]
        [RegularExpression("^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "E-mail is not valid")]

        public string EmailId { get; set; }
        //Enter Password
        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression("^.{8,15}$", ErrorMessage = "Password Length should be between 8 to 15")]

        public string Password { get; set; }
        //date and time when result is generated
        public DateTime DateOnCreation { get; set; } = DateTime.Now;

    }
}
