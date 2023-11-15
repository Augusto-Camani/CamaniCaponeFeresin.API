using System.ComponentModel.DataAnnotations;

namespace CamaniCaponeFeresin.API.Models
{
    public class AuthenticationRequestBody //Este elemento funciona igual que un DTO, lo utilizamos para pasar información personalizada a un objeto.
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
