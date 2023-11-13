using CamaniCaponeFeresin.API.Entities;

namespace CamaniCaponeFeresin.API.Data.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        IQueryable<Sale> GetAll();
        IQueryable<Sale> GetSalesByClientId(int clientId);
        Sale GetSaleById(int id);
        void AddSale(Sale sale);
        void DeleteSale(int id);
        Sale IncludeSaleDetails(Sale sale);

    }
}
