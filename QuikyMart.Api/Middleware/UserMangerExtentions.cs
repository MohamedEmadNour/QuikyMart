using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.Entites.Accounting;
using System.Security.Claims;

namespace QuikyMart.Api.Middleware
{

    public static class UserMangerExtentions 
    {
        public static async Task<AppUser?> FineUserWithAddressAsync(this UserManager<AppUser> userManager  , ClaimsPrincipal User )
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var userAddress = await userManager.Users.Include(U => U.Addresss).FirstOrDefaultAsync(U => U.Email == userEmail);

            return userAddress;
        }
    }
}
