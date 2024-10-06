using AutoMapper;
using GeekShopping.Api.Data.ObjectDTO;
using GeekShopping.Api.Model;
using GeekShopping.Api.Repository.Interfaces;
using GeekShopping.Api.Services.Interface;

namespace GeekShopping.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryDTO CategoryDTO)
        {
            var category = _mapper.Map<Category>(CategoryDTO);
            await _categoryRepository.Create(category);
            CategoryDTO.Id = category.Id; 
        }

        public async Task DeleteCategory(int id)
        {
            var category = _categoryRepository.FindById(id).Result;
            await _categoryRepository.Delete(category.Id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = _categoryRepository.FindAll();
            var retorno = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return retorno;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categories = _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryById(long id)
        {
            var category = _categoryRepository.FindById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task UpdateCategory(CategoryDTO CategoryDTO)
        {
            var category = _mapper.Map<Category>(CategoryDTO);
            await _categoryRepository.Update(category);
        }
    }
}
