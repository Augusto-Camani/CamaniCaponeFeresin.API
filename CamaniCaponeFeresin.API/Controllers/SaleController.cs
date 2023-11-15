using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CamaniCaponeFeresin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("GetAll")]
        [Authorize("AdminPolicy")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_saleService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSaleById{id}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetSaleById(int id)
        {
            try
            {
                return Ok(_saleService.GetSaleById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSalesByClientId{clientId}")]
        [Authorize("AdminPolicy")]
        public IActionResult GetSalesByClientId(int clientId)
        {
            try
            {
                return Ok(_saleService.GetSalesByClientId(clientId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddSale")]
        [Authorize("ClientPolicy")]
        public IActionResult AddSale([FromBody] SaleDTO saleDTO )
        {
            try
            {
               _saleService.AddSale(saleDTO);
               return StatusCode(201);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteSaleById")]
        [Authorize("AdminPolicy")]
        public IActionResult DeleteSaleById(int id) 
        {
            try
            {
                _saleService.DeleteSale(id);
                return NoContent();
            }
            catch 
            {
                return BadRequest(); 
            }
        }
    }
}
