using _13AugAssignment.Models;
using _13AugAssignment.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _13AugAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetAll()
        {
            var products = service.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Customer")]
        public IActionResult GetProductById(int id)
        {
            var product = service.GetProductById(id);
            if (product == null)
                return NotFound("Product not found");
            return Ok(product);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(Product product)
        {
            var product1 = service.AddProducts(product);
            return Ok(product1);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(Product product)
        {
            var product1 = service.AddProducts(product);
            return Ok(product1);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteProduct(int id)
        {
            var product3 = service.DeleteProduct(id);

            if (product3 == null)
                return NotFound();
            service.DeleteProduct(id);

            return Ok(product3);
        }
    

        
    }
}


    

