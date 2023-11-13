using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Implementations
{
    public class SaleLineRepository : Repository, ISaleLineRepository
    {
        public SaleLineRepository(AppDBContext context) : base(context)
        {
        }

        public void AddSaleLine(SaleLine line)
        {
            _context.Add(line);
            _context.SaveChanges();
        }

        public void DeleteSaleLine(int id)
        {
            _context.SaleLines.Remove(GetSaleLine(id));
            _context.SaveChanges();
        }

        public SaleLine GetSaleLine(int id)
        {
            return _context.SaleLines.Find(id);
        }

        public void UpdateSaleLine(SaleLine line)
        {
            _context.Update(line);
            _context.SaveChanges();
        }
    }
}
