using GeekShopping.Api.Model;

namespace GeekShopping.Api.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> FindAll();
        Task<IEnumerable<Category>> GetCategoriesProducts();
        Task<Category> FindById(long id);
        Task<Category> Create(Category Category);
        Task<Category> Update(Category Category);
        Task<bool> Delete(int id);
    }
}
