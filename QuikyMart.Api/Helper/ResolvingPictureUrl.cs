using AutoMapper;

using QuikyMart.Data.Entites;
using QuikyMart.Data.Entites.Order;
using QuikyMart.Service.Dtos;
using QuikyMart.Service.OrderServices.OrderDtos;

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
    public class ResolvingOrderPictureUrl : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ResolvingOrderPictureUrl(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureURL))
                return $"{_configuration["BaseUrl"]}{source.PictureURL}";

            return string.Empty;
        }

    }
}
