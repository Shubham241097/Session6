using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session6.Repository;

namespace Session6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]

        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetProducts();
            if (products == null)
            {
                return NotFound("No products found.");
            }
            return Ok(products);
        }

    }
}
