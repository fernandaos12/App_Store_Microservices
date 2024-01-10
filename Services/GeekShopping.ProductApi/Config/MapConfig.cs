using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObject;
using GeekShopping.ProductApi.Model;

namespace GeekShopping.ProductApi.Config
{
    public class MapConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapconfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mapconfig;
        }
    }
}
