using GeekShoppingWeb.Models;
using GeekShoppingWeb.Models.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GeekShoppingWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productservice;
        public ProductController(IProductService productService)
        {
            _productservice = productService ?? throw new ArgumentException("Something wrong with acess products base.");
        }
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var products = await _productservice.FindAllProducts();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public async Task<ActionResult> ProductCreate()
        {           
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _productservice.CreateProduct(model);
                if (reponse != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        // GET: ProductController/ProductUpdate/5
        [HttpGet]
        public async Task<ActionResult> ProductUpdate(int id)
        {
            var objView = await _productservice.FindProductById(id);
            if (objView == null)
            {
                return NotFound();
            }
            return View(objView);
        }

        // POST: ProductController/ProductUpdate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var obj = await _productservice.UpdateProduct(model);
                if (obj != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

       // GET: ProductController/Delete/5
        public async Task<ActionResult> ProductDelete(int? id)
        {
            //var objView = await _productservice.DeleteProductById(id);
            if (id == null)
            {
                return NotFound();
            }
            var response = await _productservice.FindProductById(id.Value);

            return View(response);
        }

        // POST: ProductController/Delete/5
        [HttpDelete()]
        public async void ProductDelete(int id)
        {
            var response = await _productservice.FindProductById(id);

            if (response != null)
            {
                throw new ArgumentException("Error Delete item");
            }
            await _productservice.DeleteProductById(response.Id);

            // return View();
            //return true;

        }
    }
}
