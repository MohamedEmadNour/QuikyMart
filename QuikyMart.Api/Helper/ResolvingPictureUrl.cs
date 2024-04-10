using AutoMapper;
using Microsoft.Extensions.Configuration;
using QuikyMart.Data.Entites;
using QuikyMart.Service.Dtos;

namespace QuikyMart.Api.Helper
{
    public class ResolvingPictureUrl : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ResolvingPictureUrl(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseUrl"]}{source.PictureUrl}";

            return string.Empty;
        }

    }
}
