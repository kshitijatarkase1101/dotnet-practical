using _14Aug.Models;
using _14Aug.Repository;
using _14Aug.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _14Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
         public ProductController(IProductService service)
        {
            this .service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Getall()
        {
            service.GetProducts();
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetProduct(int id)
        {
            var prod = service.GetProductById( id);
            if (prod == null)
                return NotFound("No Product found");
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddProduct(Product product)
        {
            service.AddProduct(product);
            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateProduct(Product product)
        {
            service.UpdateProduct(product);
            return Ok();
        }
          
    }
}
