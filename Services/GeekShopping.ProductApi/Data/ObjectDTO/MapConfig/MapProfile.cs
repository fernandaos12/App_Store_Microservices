using AutoMapper;
using GeekShopping.Api.Model;

namespace GeekShopping.Api.Data.ObjectDTO.MapConfig
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            this.CreateMap<Category, CategoryDTO>().ReverseMap();
          //  this.CreateMap<Category, CategoryDTO>().ForMember(dto => dto.Produts, m => m.MapFrom(p => p.Produts));

            this.CreateMap<Product, ProductDTO>().ReverseMap();
           // .ForMember(d=>d.Category, m=>m.MapFrom(p=>p.Category.Id));
        }
        
    }
}
