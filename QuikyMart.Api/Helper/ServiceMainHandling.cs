using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.DB.Context;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositores.Repositories;
using QuikyMart.Service.ExceptionsHandeling;

namespace QuikyMart.Api.Helper
{
    public class ServiceMainHandling
    {
        public static WebApplicationBuilder ApplyServiceMainHandling(WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped(typeof(IGenericRepositories<,>), typeof(GenericRepositories<,>));



            builder.Services.AddDbContext<QuikyMartDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            });

            builder.Services.Configure<ApiBehaviorOptions>(Option =>
            {
                Option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState
                                .Where(Ex => Ex.Value.Errors.Count() > 0)
                                .SelectMany(Ex => Ex.Value.Errors)
                                .Select(Ex => Ex.ErrorMessage).ToList();

                    var responseApi = new ValidationErrorResponse
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(responseApi);
                };
            });

            //builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfile()));
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            return builder;
        }
    }
}
