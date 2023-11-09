namespace CamaniCaponeFeresin.API.Data.Repositories.Interfaces
{
    public interface IRepository //Creamos el repositorio (Un patrón de diseño para hacer una abrstracción entre la capa de datos y la base de datos).
    {
        public bool SaveChanges(); //Creamos la firma de la interfaz.
                                   //SaveChanges() es un método que puede usar la clase DbContext.
                                   //Este método, guarda los datos hechos en el contexto, dentro de la DB (Data Base).
    }
}
