using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;

namespace CamaniCaponeFeresin.API.Data.Repositories.Implementations
{
    public class Repository : IRepository //Implementamos la interfaz IRepository
    {
        internal readonly DBContext.AppDBContext _context; //Creamos una variable de instancia, del tipo de nuestro Contexto personalizado.

        public Repository(DBContext.AppDBContext context) //Realizamos la inyección de dependencia de nuestro contexto en el Repositorio.
        {
            this._context = context;
        }

        public bool SaveChanges() //Aplicamos el método del contrato.Este método guarda los cambios en la base de datos si hay un cambio devuelve "true".
        {
            return (_context.SaveChanges() >= 0); //Ejecutamos el método con nuestra variable de instancia que tiene la inyección de dependencia.
        }
    }
}
