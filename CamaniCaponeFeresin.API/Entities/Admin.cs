namespace CamaniCaponeFeresin.API.Entities
{
    public class Admin : User
    {
        public Admin()
        {
           UserType= (CamaniCaponeFeresin.API.Enums.UserType.Admin);
        }
    }
}
