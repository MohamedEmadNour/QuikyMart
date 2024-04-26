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
        [RegularExpression("^\\d{3}[A-Z]{3}\\d{3}$\r\n" , 
            ErrorMessage = "Password Must Be 6 Char Like 123AAA123")]
        public string Password { get; set; }
    }
}
