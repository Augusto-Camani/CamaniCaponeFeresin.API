using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public Product GetByName(string name);
        public void Add(ProductDTO productDTO);
        public void Update(ProductDTO productDTO);
        public void Delete(int id);
    }
}
