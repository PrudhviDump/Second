using AutoMapper;
using Second.Business_Logic_Layer.DTO;
using Secondzz.Business_Logic_Layer.DTO;
using Secondzz.Data_Access_Layer.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace SwapPortal_API.Infrastructure
{
    public class AutoMapperProfiles : Profile

    {
        public AutoMapperProfiles()
        {
            CreateMap<AddUserRequestDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, User>().ReverseMap();
            CreateMap<AddProductRequestDTO, Product>()
                .ForMember(O => O.ProductName, P => P.MapFrom(src => src.ProductName))
                .ForMember(O => O.ProductImageUrl, P => P.MapFrom(src => src.ProductImageUrl))
                .ForMember(O => O.ProductDetails, P => P.MapFrom(src => src.ProductDetails))
                .ForMember(O => O.ProductPrice, P => P.MapFrom(src => src.ProductPrice))
                .ForMember(O => O.UserId, P => P.MapFrom(src => src.UserId))
                .ForMember(O => O.CategoryId, P => P.MapFrom(src => src.CategoryId));
                //.ForMember(O => O.Status, opt => opt.MapFrom(src => Status))
            //    .ForMember(O => O.Status, opt => opt.NullSubstitute("Unverified"));
               
            
                
            CreateMap<UpdateUserRequestDTO, Product>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();

         
        }
    }
}