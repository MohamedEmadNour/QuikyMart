using AutoMapper;
using QuikyMart.Data.Entites;
using QuikyMart.Data.Entites.Accounting;
using QuikyMart.Data.Entites.Order;
using QuikyMart.Service.Dtos;
using QuikyMart.Service.OrderServices.OrderDtos;

namespace QuikyMart.Api.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product , ProductDTO>()
                .ForMember(P => P.Brand , O => O.MapFrom(S => S.Brand.Name))
                .ForMember(P => P.Type , O => O.MapFrom(S => S.Type.Name))
                //.ForMember(P => P.PictureUrl , O => O.MapFrom(S => $"https://localhost:7089/{S.PictureUrl}"))
                .ForMember(P => P.PictureUrl , O => O.MapFrom<ResolvingPictureUrl>())
                ;


            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<AddressDTO, ShippingAddress>().ReverseMap();
            CreateMap<OrderR, OrderResultDTO>()
                .ForMember(OR => OR.deliveryMethodName, OP => OP.MapFrom(S => S.deliveryMethod.ShortName))
                .ForMember(OR => OR.ShippingPrice, OP => OP.MapFrom(S => S.deliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(OI => OI.ProductNameId, OP => OP.MapFrom(S => S.ProductId))
                .ForMember(OI => OI.ProductName, OP => OP.MapFrom(S => S.ProductName))
                //.ForMember(OI => OI.PictureURL, OP => OP.MapFrom(S => S.PictureURL))
                .ForMember(OI => OI.PictureURL, O => O.MapFrom<ResolvingOrderPictureUrl>());


            
        }
    }
}
