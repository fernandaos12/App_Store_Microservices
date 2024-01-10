using GeekShopping.ProductApi.Data.ValueObject;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindbyId(long id)
        {
            var product = await _repo.FindById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _repo.FindAll();            
            return products;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVO prod)
        {
            if(prod == null)
            {
                return BadRequest();
            }
            var product = await _repo.Create(prod);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductVO prod)
        {
            if(prod == null)
            {
                return BadRequest();
            }
            var product = await _repo.Update(prod);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var status = await _repo.Delete(id);
            if(status == null)
            {
                return BadRequest();
            }
            return Ok(status);
        }
    }
}
