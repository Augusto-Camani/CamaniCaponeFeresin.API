using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public class SaleLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        

        [ForeignKey("PurchaseId")]
        public Sale Sale { get; set; }
        public int SaleId { get; set; }
       
        public ICollection<Product> Products { get; set; } = new List<Product>(); //Usamos un ICollection, ya que esta puede conformar una lista de Objetos.

    }
}
