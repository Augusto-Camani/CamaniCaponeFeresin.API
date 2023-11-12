using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Implementations;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamaniCaponeFeresin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var product = _productService.GetById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("ByName/{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return Ok(_productService.GetByName(name));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                _productService.Add(productDTO);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                var existingProduct = _productService.GetById(id); // Obtén el producto existente por su ID
                if (existingProduct == null)
                {
                    return NotFound(); // Devuelve un código de estado 404 Not Found si el producto no se encuentra
                }
                else
                {   // Realiza la actualización utilizando tu servicio
                    existingProduct.Name =  productDTO.Name;
                    existingProduct.Description = productDTO.Description;
                    existingProduct.Price = productDTO.Price; 
                    return NoContent(); // Devuelve un código de estado 204 No Content para indicar una actualización exitosa
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}