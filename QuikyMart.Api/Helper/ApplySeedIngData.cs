using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.DB.Context;
using QuikyMart.Data.Entites.Accounting;
using QuikyMart.Repositores;
using QuikyMart.Repositories;

namespace QuikyMart.Api.Helper
{
    public class ApplySeedIngData
    {
        public static async Task ApplySeeingDataAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                var UserManger = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                try
                {
                    var context = serviceProvider.GetRequiredService<QuikyMartDBContext>();
                    var Identity = serviceProvider.GetRequiredService<AppIdentityDbContext>();

                    await context.Database.MigrateAsync();
                    await Identity.Database.MigrateAsync();



                    await SeedIngData.SeedingData(context , loggerFactory);
                    await SeedingUsers.ApplyUsersSeeding(UserManger);

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeedIngData>();
                    logger.LogError(ex.Message);
                }
            }

        }
    }
}
