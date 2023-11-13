using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public float Price { get; set; } = 0;
        public ICollection<SaleLine> SaleLines { get; set;} = new List<SaleLine>();
    }
}
