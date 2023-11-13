using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Interfaces
{
    public interface ISaleLineRepository
    {
        public SaleLine GetSaleLine(int id);
        public void AddSaleLine(SaleLine line);
        public void UpdateSaleLine(SaleLine line);
        public void DeleteSaleLine(int id);
    }
}
