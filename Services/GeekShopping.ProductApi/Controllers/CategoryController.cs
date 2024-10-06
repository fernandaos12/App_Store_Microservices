using GeekShopping.Api.Data.ObjectDTO;
using GeekShopping.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProduts()
        {
            var categories = await _categoryService.GetCategories();
            if (categories == null)
            {
                return NotFound("Categories not found");
            }
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var categories = await _categoryService.GetCategoryById(id);
            if (categories == null)
            {
                return NotFound("Category not found");
            }
            return Ok(categories);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            if (id != category.Id || category.Id == null)
            {
                return BadRequest("Erro ao Atualizar");
            }
            await _categoryService.UpdateCategory(category);
            return Ok(category);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            await _categoryService.DeleteCategory(id);
            return Ok(category);
        }
        
        [HttpPost()]
        public async Task<ActionResult<CategoryDTO>> PostCategory([FromBody]CategoryDTO CategoryDTO)
        {
            if (CategoryDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            await _categoryService.AddCategory(CategoryDTO);
            return new CreatedAtRouteResult("GetCategory", new { id = CategoryDTO.Id }, CategoryDTO);
        }

    }
}
