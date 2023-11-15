using AutoMapper;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Profiles
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<SaleDTO, Sale>(); //Mappeo Múltible bidireccional.
            CreateMap<Sale, SaleDTO>();
        }
    }
}
