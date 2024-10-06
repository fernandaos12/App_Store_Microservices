using AutoMapper;
using GeekShopping.Api.Repository.Interfaces;
using GeekShopping.Api.Data.ObjectDTO;
using GeekShopping.Api.Services.Interface;
using GeekShopping.Api.Model;

namespace GeekShopping.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO ProductDTO)
        {
            var product = _mapper.Map<Product>(ProductDTO);
            await _ProductRepository.Create(product);
            ProductDTO.Id = product.Id;
        }

        public async Task DeleteProduct(int id)
        {
            var Product = _ProductRepository.FindById(id).Result;
            await _ProductRepository.Delete(Product.Id);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var Products = _ProductRepository.FindAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(Products);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsProducts()
        {
            var Products = _ProductRepository.FindAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(Products);
        }

        public async Task<ProductDTO> GetProductById(long id)
        {
            var Product = _ProductRepository.FindById(id);
            return _mapper.Map<ProductDTO>(Product);
        }

        public async Task UpdateProduct(ProductDTO ProductDTO)
        {
            var product = _mapper.Map<Product>(ProductDTO);
            await _ProductRepository.Update(product);
        }
    }
}
