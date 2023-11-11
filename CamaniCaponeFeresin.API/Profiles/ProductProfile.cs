using AutoMapper;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
