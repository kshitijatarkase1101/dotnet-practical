using _10AugAssignment.Models;
using _10AugAssignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _10AugAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        private readonly IPurchaseService service;
        public PurchaseController(IPurchaseService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()

        {
            return Ok(service.GetPurchases());
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var purchase = service.GetPurchaseById(id);
            if (purchase == null)
                return NotFound("Purchase not found");
            return Ok(purchase);
        }
        [HttpPost]
        public IActionResult Create(Purchase purchase)
        {
            service.CreatePurchase(purchase);
            return Ok(purchase);
        }

    }

}
