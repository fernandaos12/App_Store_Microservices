using GeekShopping.Api.Data.ObjectDTO;

namespace GeekShopping.Api.Services.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
        Task<CategoryDTO> GetCategoryById(long id);
        Task AddCategory(CategoryDTO CategoryDTO);
        Task UpdateCategory(CategoryDTO CategoryDTO);
        Task DeleteCategory(int id);

    }
}
