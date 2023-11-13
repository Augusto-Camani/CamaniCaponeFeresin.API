using AutoMapper;
using CamaniCaponeFeresin.API.Data.Repositories.Implementations;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;

namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class SaleLineService : ISaleLineService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleLineRepository _saleLineRepository;
        private readonly IMapper _mapper;
        public SaleLineService(ISaleLineRepository saleLineRepository, ISaleRepository saleRepository, IMapper mapper)
        {
            _saleLineRepository = saleLineRepository;
            _mapper = mapper;
        }

        public SaleLine GetSaleLine(int id)
        {
            return _saleLineRepository.GetSaleLine(id);
        }
        public void AddSaleLine(SaleLineDTO lineDTO)
        {
            var line = _mapper.Map<SaleLine>(lineDTO);
            _saleLineRepository.AddSaleLine(line);
        }
        public void UpdateSaleLine(int id, int saleId, SaleLineDTO lineDTO)
        {
            // Verificar si la venta existe
            var existingSale = _saleRepository.GetSaleById(saleId);

            if (existingSale == null)
            {
                return;
            }

            // Verificar si la línea de venta existe en la venta
            var existingSaleLine = existingSale.SaleLines.FirstOrDefault(sl => sl.Id == id);

            if (existingSaleLine == null)
            {
                // La línea de venta no existe en la venta, manejar según tus requerimientos.
                return;
            }

            // Actualizar propiedades de la línea de venta con los valores de lineDTO
            existingSaleLine.Quantity = lineDTO.Quantity; // Puedes agregar otras propiedades según sea necesario
            existingSaleLine.ProductId = lineDTO.ProductId;

            _saleLineRepository.UpdateSaleLine(existingSaleLine);
        }
        public void DeleteSaleLine(int id)
        {
            _saleLineRepository.DeleteSaleLine(id);
        }
    }
}
