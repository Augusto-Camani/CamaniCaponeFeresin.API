﻿using AutoMapper;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            _productService = productService; //Inyección de dependencia del servicio de producto.
        }

        [HttpGet("GetAll")]
        [Authorize("BothPolicy")]
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

        [HttpGet("GetById/{id}")]
        [Authorize("AdminPolicy")]
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

        [HttpGet("GetByName/{name}")]
        [Authorize("BothPolicy")]
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

        [HttpPost("CreateProduct")]
        [Authorize("AdminPolicy")]
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

        [HttpPut("UpdateProduct/{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult Update(int id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                _productService.Update(id, productDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Dependiendo del tipo de excepción que arroje el servicio, puedes personalizar el manejo de errores aquí
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        [Authorize("AdminPolicy")]
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