using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Services.Interfaces;

namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IEnumerable<Sale> GetAll()
        {
           return _saleRepository.GetAll();
        }

        public Sale GetSaleBy(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetSalesByClientId(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
