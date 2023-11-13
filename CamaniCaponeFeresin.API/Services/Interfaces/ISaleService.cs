using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface ISaleService
    {
        public IEnumerable<Sale> GetAll();
        public IEnumerable<Sale> GetSalesByClientId(int clientId);
        public Sale GetSaleBy(int id);
    }
}
