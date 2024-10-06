using GeekShopping.Api.Data.ObjectDTO;
using GeekShopping.Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            var products = await _service.GetProducts();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindbyId(long id)
        {
            var product = await _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO prod)
        {
            if (prod == null)
            {
                return BadRequest("Erro ao adicionar produto");
            }

            await _service.AddProduct(prod);

            return new CreatedAtRouteResult("FindAll", new { id = prod.Id }, prod);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] ProductDTO prod)
        {
            if (prod == null)
            {
                return BadRequest();
            }
            await _service.UpdateProduct(prod);
            return Ok(prod);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prod = await _service.GetProductById(id);
            if (prod == null)
            {
                return NotFound("Product NotFound in Server");
            }
            await _service.DeleteProduct(id);
            return Ok(prod);
        }
    }
}
