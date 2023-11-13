using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface ISaleLineService
    {
        public SaleLine GetSaleLine(int id);
        public void AddSaleLine(SaleLineDTO lineDTO);
        public void UpdateSaleLine(int id, int saleId, SaleLineDTO lineDTO);
        public void DeleteSaleLine(int id);
    }
}
