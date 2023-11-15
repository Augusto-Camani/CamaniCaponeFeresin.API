using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public class Client : User
    {
        public Client()
        {
            UserType = (CamaniCaponeFeresin.API.Enums.UserType.Client); //Dentro del constructor asignamos el tipo de UserType, propio del Client.
        }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
