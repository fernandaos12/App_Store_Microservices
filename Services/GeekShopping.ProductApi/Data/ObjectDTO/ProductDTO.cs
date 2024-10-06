using GeekShopping.Api.Model;

namespace GeekShopping.Api.Data.ObjectDTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
