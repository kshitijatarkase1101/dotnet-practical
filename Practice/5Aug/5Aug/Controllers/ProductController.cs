using _5Aug.Models;
using _5Aug.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository service;

        public ProductController(IProductRepository service)
        {
            this.service = service;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(service.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = service.GetProduct(id);
            if (product == null)
                return NotFound("Product is not available");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            service.AddProduct(product);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            service.UpdateProduct(product);
            return Ok("Product updated successfully");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            service.DeleteProduct(id);
            return Ok("Product Deleted successfully");
        }
        
    }
}
