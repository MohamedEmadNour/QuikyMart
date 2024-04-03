using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.DB.Context;
using QuikyMart.Repositores;

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
                try
                {
                    var context = serviceProvider.GetRequiredService<QuikyMartDBContext>();

                    await context.Database.MigrateAsync();

                    await SeedIngData.SeedingData(context , loggerFactory);

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
