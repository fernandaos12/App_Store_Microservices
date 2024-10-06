using GeekShopping.Api.Data.ObjectDTO;
using GeekShopping.Api.Model;

namespace GeekShopping.Api.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product> FindById(long id);
        Task<Product> Create(Product Product);
        Task<Product> Update(Product Product);
        Task<bool> Delete(long id);
    }
}
