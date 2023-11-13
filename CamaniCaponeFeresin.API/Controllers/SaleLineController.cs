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

    }
}

