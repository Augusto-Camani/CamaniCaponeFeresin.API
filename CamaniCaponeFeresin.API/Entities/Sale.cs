using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public int ClientId { get; set; }
        
        public ICollection<SaleLine> SaleLines { get; set; } = new List<SaleLine>();

    }
}
