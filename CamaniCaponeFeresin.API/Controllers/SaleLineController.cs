using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CamaniCaponeFeresin.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleLineController : Controller
    {
        private readonly ISaleLineService _saleLineService;
        public SaleLineController(ISaleLineService saleLineService)
        {
            _saleLineService = saleLineService;
        }

        [HttpGet("GetSaleLine/{id}")]
        public IActionResult GetSaleLine(int id)
        {
            return Ok(_saleLineService.GetSaleLine(id));
        }

        [HttpPost("AddSaleLine")]
        public IActionResult AddSaleLine([FromBody] SaleLineDTO saleLineDTO,int saleId)
        {
            try
            {
                _saleLineService.AddSaleLine(saleId, saleLineDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSaleLine/{id}")]
        public IActionResult UpdateSaleLine(int id, [FromBody] SaleLineDTO saleLineDTO)
        {
            try 
            {
                _saleLineService.UpdateSaleLine( id , saleLineDTO);
                return Ok();
            }
            catch (Exception ex) 
            {
            return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSaleLine{id}")]
        public IActionResult DeleteSaleLine(int id)
        {
            try 
            {
                _saleLineService.DeleteSaleLine(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

