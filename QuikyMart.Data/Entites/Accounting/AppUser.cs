using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Data.Entites.Accounting
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public Address Addresss { get; set; }
    }
}
