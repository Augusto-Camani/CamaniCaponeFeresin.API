using AutoMapper;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Profiles
{
    public class ProductProfile : Profile //Hereda de Profile, para poder funcionar como un perfil y poder mappear los objetos.
    {
        public ProductProfile() {

            CreateMap<ProductDTO, Product>(); //Permitimos que el auto mappear rellene las celdas en la base de datos de DTO a Objeto
            CreateMap<Product, ProductDTO>(); //También de Objeto a DTO.
        }
    }
}
