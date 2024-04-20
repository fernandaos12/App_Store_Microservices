namespace GeekShoppingWeb.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Size { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
