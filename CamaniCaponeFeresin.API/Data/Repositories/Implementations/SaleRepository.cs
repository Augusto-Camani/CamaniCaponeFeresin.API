using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using CamaniCaponeFeresin.API.Entities;
using Microsoft.EntityFrameworkCore;


namespace CamaniCaponeFeresin.API.Data.Repositories.Implementations
{
    public class SaleRepository : Repository , ISaleRepository
    {
        public SaleRepository(AppDBContext context) : base(context)
        {
        }
        public IQueryable<Sale> GetAll()
        {
           return _context.Sales;
        }
        public Sale GetSaleById(int id)
        {
            return _context.Sales.Find(id);
        }
        public IQueryable<Sale> GetSalesByClientId(int clientId)
        {
            return _context.Sales.Where(x => x.ClientId == clientId);
        }
        public void AddSale(Sale sale)
        {
            _context.Add(sale);
            _context.SaveChanges();
        }  
        public void DeleteSale(int id)
        {
            var sale = GetSaleById(id);

            if (sale != null)
            {
                // Eliminar las líneas de venta asociadas antes de eliminar la venta
                _context.SaleLines.RemoveRange(sale.SaleLines);

                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }
        public Sale IncludeSaleDetails(Sale sale)
        {
            return _context.Sales
                .Include(s => s.Client)
                .Include(s => s.SaleLines)
                    .ThenInclude(sl => sl.Product)  
                .FirstOrDefault(s => s.Id == sale.Id);
        }

    }
}

