namespace CamaniCaponeFeresin.API.Entities
{
    public class Admin : User
    {
        public Admin()
        {
           UserType= (CamaniCaponeFeresin.API.Enums.UserType.Admin); //Dentro del constructor asignamos el UserType propio del Admin.
        }
    }
}
