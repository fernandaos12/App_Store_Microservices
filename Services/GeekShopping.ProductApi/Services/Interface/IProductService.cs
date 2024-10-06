using GeekShopping.Api.Data.ObjectDTO;

namespace GeekShopping.Api.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<IEnumerable<ProductDTO>> GetProductsProducts();
        Task<ProductDTO> GetProductById(long id);
        Task AddProduct(ProductDTO ProductDTO);
        Task UpdateProduct(ProductDTO ProductDTO);
        Task DeleteProduct(int id);
    }
}
