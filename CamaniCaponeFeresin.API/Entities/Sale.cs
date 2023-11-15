using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CamaniCaponeFeresin.API.Entities
{
    public class Sale
    {
        public Sale()
        {
            CalculateTotalPrice();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float? TotalPrice { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public ICollection<SaleLine> SaleLines { get; set; } = new List<SaleLine>();

        public void CalculateTotalPrice()
        {
            // Calcular el precio total de la venta sumando los precios totales de todas las líneas de venta
            TotalPrice = SaleLines?.Sum(sl => sl.TotalPrice) ?? 0;
        }

    }
}
