using GeekShoppingWeb.Models.Services.IServices;
using GeekShoppingWeb.Utils;

namespace GeekShoppingWeb.Models.Services
{
    /// <summary>
    /// Implementacao product service interface com IHttpFactory
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentException("Error Http client");
        }
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong when create products");
            }
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<bool>();
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
