using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Dtos;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(ProductCreateDTO dto)
        {
            var product = _service.CreateProduct(dto);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductUpdateDTO dto)
        {
            if (!_service.UpdateProduct(id, dto))
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteProduct(id))
                return NotFound();

            return NoContent();
        }
    }
}
