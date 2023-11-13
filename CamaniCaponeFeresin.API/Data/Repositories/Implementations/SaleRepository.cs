using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Implementations
{
    public class SaleRepository : Repository , ISaleRepository
    {
        public SaleRepository(AppDBContext context) : base(context)
        {
        }

        public IEnumerable<Sale> GetAll()
        {
           return _context.Sales;
        }
        public Sale GetSaleBy(int id)
        {
            return _context.Sales.Find(id);
        }
        public IEnumerable<Sale> GetSalesByClientId(int clientId)
        {
            return _context.Sales.Where(x => x.ClientId == clientId);
        }
    }
}

