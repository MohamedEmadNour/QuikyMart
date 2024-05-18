using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Service.Dtos
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
    public class RegisterDTO
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d{3})(?=.*[A-Za-z]{3}).{6,}$", 
            ErrorMessage = "Password Must Be 6 Char Like 1234*AAaa*1234")]
        public string Password { get; set; }
    }

    public class UserLoginDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
