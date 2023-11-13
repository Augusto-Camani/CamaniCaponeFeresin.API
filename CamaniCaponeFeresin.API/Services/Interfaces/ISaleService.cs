using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetAll();
        IEnumerable<Sale> GetSalesByClientId(int clientId);
        Sale GetSaleById(int id);
        void AddSale(SaleDTO saleDTO);
        void DeleteSale(int id);
    }
}
