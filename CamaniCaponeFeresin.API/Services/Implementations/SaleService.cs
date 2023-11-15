using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;

namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleLineRepository _saleLineRepository;
        public SaleService(ISaleRepository saleRepository, IMapper mapper, ISaleLineRepository saleLineRepository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _saleLineRepository = saleLineRepository;
        }
        public IEnumerable<Sale> GetAll()
        {
            var sales = _saleRepository.GetAll()
                .Include(s => s.Client)
                .Select(s => new Sale
                {
                    Id = s.Id,

                    Client = new Client
                    {
                        Id = s.Client.Id,
                        UserName = s.Client.UserName,
                    },

                    SaleLines = s.SaleLines.Select(sl => new SaleLine
                    {
                        Id = sl.Id,
                        Quantity = sl.Quantity,
                        ProductId = sl.ProductId,

                        Product = new Product
                        {
                            Id = sl.Product.Id,
                            Name = sl.Product.Name,
                            Price = sl.Product.Price,
                            Description = sl.Product.Description
                        },
                        TotalPrice = (float)(sl.Quantity * sl.Product.Price)

                    }).ToList(),
                    TotalPrice = s.SaleLines.Sum(sl => (float)(sl.Quantity * sl.Product.Price))
                })
             
                .ToList();

            return sales;
        }
        public Sale GetSaleById(int id)
        {
            var sale = _saleRepository.GetSaleById(id);

            if (sale != null)
            {
                _saleRepository.IncludeSaleDetails(sale);
                sale.TotalPrice = sale.SaleLines.Sum(sl => (float)(sl.Quantity * sl.Product.Price));
            }

            return sale;
        }

        public IEnumerable<Sale> GetSalesByClientId(int clientId)
        {
            var sales = _saleRepository.GetSalesByClientId(clientId)
                .Include(s => s.Client)
                .Include(s => s.SaleLines)
                    .ThenInclude(sl => sl.Product)
                .ToList();

            // Calculamos el TotalPrice para cada venta en la lista.
            sales.ForEach(s =>
            {
                s.TotalPrice = s.SaleLines.Sum(sl => (float)(sl.Quantity * sl.Product.Price));
            });

            return sales;
        }
        public void AddSale(SaleDTO saleDTO)
        {
            var sale = _mapper.Map<Sale>(saleDTO);
            _saleRepository.AddSale(sale);
        }


        public void DeleteSale(int id)
        {
            _saleRepository.DeleteSale(id);
        }
    }
}

