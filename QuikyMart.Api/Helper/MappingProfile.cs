using AutoMapper;
using QuikyMart.Data.Entites;
using QuikyMart.Service.Dtos;

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
        }
    }
}
