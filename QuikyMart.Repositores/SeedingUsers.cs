using Microsoft.AspNetCore.Identity;
using QuikyMart.Data.Entites.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Repositores
{
    public static class SeedingUsers
    {
        public static async Task ApplyUsersSeeding(UserManager<AppUser> users)
        {
            if (!users.Users.Any())
            {
                var user = new AppUser()
                {
                    UserName = "M.Emad",
                    Email = "MohamedEmad@outlook.com",
                    FullName = "Mohamed Emad",
                    PhoneNumber = "1234567890",
                    
                };

                await users.CreateAsync(user , "P@$sw0rd");
            }

        } 

    }
}
