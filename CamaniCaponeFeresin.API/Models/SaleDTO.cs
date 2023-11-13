namespace CamaniCaponeFeresin.API.Models
{
    public class SaleDTO
    { 
        public int ClientId { get; set; }
        public List<SaleLineDTO> SaleLines { get; set; }
    }
}
