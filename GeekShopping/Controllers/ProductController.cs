using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GeekShopping.Models;
using GeekShopping.ProductApi.Repository;

namespace GeekShopping.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productservice;

    public ProductController(IProductRepository productservice)
    {
        _productservice = productservice;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productservice.FindAll();
        return View(products);
    }
    public IActionResult Create()
    {
        return View();
    } 

}
