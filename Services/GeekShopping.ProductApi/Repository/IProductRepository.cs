using GeekShopping.ProductApi.Data.ValueObject;

namespace GeekShopping.ProductApi.Repository
{
    public interface IProductRepository
    {

        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(long id);
        Task<ProductVO> Create(ProductVO productvo);
        Task<ProductVO> Update(ProductVO productvo);
        Task<ProductVO> Delete(long id);
    }
}
