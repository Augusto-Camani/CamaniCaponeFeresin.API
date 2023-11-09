using System.ComponentModel.DataAnnotations.Schema;

namespace CamaniCaponeFeresin.API.Entities
{
    public class Client : User
    {
        public Client()
        {
            UserType = "Client";
        }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
