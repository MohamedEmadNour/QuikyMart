using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuikyMart.Data.DB.Context;
using QuikyMart.Data.Entites;
using QuikyMart.Data.Entites.Accounting;
using QuikyMart.Repositores.Interfaces;
using QuikyMart.Repositores.Repositories;
using QuikyMart.Service.ExceptionsHandeling;
using QuikyMart.Service.ServicesJWT;
using StackExchange.Redis;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using QuikyMart.Service.OrderServices;

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
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IBasketReopsitories, BasketReopsitories>();
            //builder.Services.AddScoped(typeof(IGenericRepositories<,>), typeof(GenericRepositories<,>));
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ITokenService , TokenService>();
            builder.Services.AddIdentity<AppUser , IdentityRole>( O =>
            {
                //O.Password.RequireDigit = true;
                //O.Password.RequiredLength = 6;

            } ).AddEntityFrameworkStores<AppIdentityDbContext>();


            builder.Services.AddDbContext<QuikyMartDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            }); 
            
            builder.Services.AddDbContext<AppIdentityDbContext>(option =>
            { 
                option.UseSqlServer(builder.Configuration.GetConnectionString("AppUserConnection"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(
                (serversProvider) =>
                {
                    var Connerction = builder.Configuration.GetConnectionString("Redis");
                    return ConnectionMultiplexer.Connect(Connerction);
                }

            );

            builder.Services.AddAuthentication(

                Op =>
                {
                    Op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    Op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }

                ).AddJwtBearer(
                
                    O => O.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JWT:ValidationIssuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:Validationaudience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey =  true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                }
                );



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
