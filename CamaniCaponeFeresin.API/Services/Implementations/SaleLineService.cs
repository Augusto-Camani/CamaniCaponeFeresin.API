using AutoMapper;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;
using CamaniCaponeFeresin.API.DBContext;
using Microsoft.EntityFrameworkCore;


namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class SaleLineService : ISaleLineService
    {
        private readonly AppDBContext _context;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleLineRepository _saleLineRepository;
        private readonly IMapper _mapper;
        public SaleLineService(ISaleLineRepository saleLineRepository, ISaleRepository saleRepository, IMapper mapper, AppDBContext appDBContext, ILogger<SaleLineService> logger)
        {
            _context = appDBContext;
            _saleRepository = saleRepository;
            _saleLineRepository = saleLineRepository;
            _mapper = mapper;
        }

        public SaleLine GetSaleLine(int id)
        {
            var saleLine = _saleLineRepository.GetSaleLine(id);

            if (saleLine != null)
            {
                // Cargamos la propiedad de navegación "Product" al recuperar la SaleLine
                _context.Entry(saleLine)
                    .Reference(sl => sl.Product)
                    .Load();
            }

            return saleLine;
        }
        public void UpdateSaleLine(int saleLineId, SaleLineDTO saleLineDTO)
        {
            // Obtenemos la SaleLine por su Id.
            var saleLine = _saleLineRepository.GetSaleLine(saleLineId);

            if (saleLine != null)
            {
                // Actualizar propiedades de la SaleLine con los datos del DTO.
                _mapper.Map(saleLineDTO, saleLine);

                // Guardar cambios en la base de datos.
                _context.SaveChanges();
            }
        }

        public void AddSaleLine(int saleId, SaleLineDTO saleLineDTO)
        {
                // Obtener la venta por su Id.
                var sale = _saleRepository.GetSaleById(saleId);

                if (sale != null)
                {
                    // Mapear DTO a entidad SaleLine.
                    var saleLine = _mapper.Map<SaleLine>(saleLineDTO); //Mappeo del objeto completo.
                    // Asociar la SaleLine con la venta.
                    saleLine.Sale = sale;

                    // Agregamos la SaleLine a la colección de SaleLines
                    sale.SaleLines.Add(saleLine);

                    // Guardamos cambios en la base de datos.
                    _context.SaveChanges();
                }
        }

        public void DeleteSaleLine(int id)
        {
            _saleLineRepository.DeleteSaleLine(id);
        }
    }
}
