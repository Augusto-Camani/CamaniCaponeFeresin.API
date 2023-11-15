﻿using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamaniCaponeFeresin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
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

        [HttpGet("GetById/{id}")]
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

        [HttpGet("GetByName/{name}")]
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

        [HttpPost("CreateClient")]
        public IActionResult CreateClient([FromBody] UserDTO userDTO)
        {

            _userService.AddClient(userDTO);
            return StatusCode(201);
        }

        [HttpPost("CreateAdmin")]
        public IActionResult CreateAdmin([FromBody] UserDTO adminDTO)
        {

            _userService.AddAdmin(adminDTO);
            return StatusCode(201);
        }


        [HttpPut("UpdateUser/{id}")]
        public IActionResult Update(int id, [FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.Update(id, userDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Dependiendo del tipo de excepción que arroje el servicio, puedes personalizar el manejo de errores aquí
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
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
