using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Implementations;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamaniCaponeFeresin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
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
                var product = _userService.GetById(id);

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
                return Ok(_userService.GetByUserName(name));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.Add(userDTO);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDTO userDTO)
        {
                try
                {
                var existingUser = _userService.GetById(id); // Obtén el producto existente por su ID
                if (existingUser == null)
                {
                    return NotFound(); // Devuelve un código de estado 404 Not Found si el producto no se encuentra
                }
                else
                {   
                   
                    // Realiza la actualización utilizando tu servicio
                    existingUser.UserName = userDTO.UserName;
                    existingUser.Password = userDTO.Password;
                    existingUser.Email = userDTO.Email;
                    
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
                _userService.Delete(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
