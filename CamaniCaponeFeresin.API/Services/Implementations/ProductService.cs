using AutoMapper;
using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;

namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;  
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetByName(string name)
        {
            return _productRepository.GetByName(name);
        }

        public void Add(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productRepository.Add(product);
        }

        public void Update(int id, ProductDTO productDTO)
        {
            var existingProduct = _productRepository.GetById(id);

            if (existingProduct == null)
            {
                // Manejar el caso en el que el producto no existe
                throw new Exception("Producto no encontrado");
            }

            // Mapear las propiedades relevantes del DTO a la entidad existente
            existingProduct.Name = productDTO.Name;
            existingProduct.Description = productDTO.Description;
            existingProduct.Price = productDTO.Price;

            // Actualizar la entidad en el repositorio
            _productRepository.Update(existingProduct);
        }
        public void Delete(int id)
        {
           _productRepository.Delete(id);
        }
    }
}
