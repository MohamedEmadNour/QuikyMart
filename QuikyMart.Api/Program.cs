using Microsoft.AspNetCore.Builder;
using QuikyMart.Api.Helper;
using QuikyMart.Api.Middleware;

namespace QuikyMart.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ServiceMainHandling.ApplyServiceMainHandling(builder);

            var app = builder.Build();

            await ApplySeedIngData.ApplySeeingDataAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseMiddleware<ServiceApiMiddleware>();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
