using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public class SaleLine
    {
        public SaleLine()
        {
            CalculateTotalPrice();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float? TotalPrice { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }
        public int SaleId { get; set; }
       
        public ICollection<Product> Products { get; set; } = new List<Product>(); //Usamos un ICollection, ya que esta puede conformar una lista de Objetos.

        public void CalculateTotalPrice()
        {
           // Calcular el precio total de la línea de venta multiplicando la cantidad por el precio del producto
           TotalPrice = Quantity * (Product?.Price ?? 0);
        }

    }
}
