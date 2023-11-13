using AutoMapper;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Profiles
{
    public class SaleLineProfile : Profile
    {
        public SaleLineProfile()
        {
            CreateMap<SaleLineDTO, SaleLine>();
        }
    }
}
