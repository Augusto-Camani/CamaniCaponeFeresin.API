using AutoMapper;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() //Realizamos esto así, ya que Usuario es una clase abstracta y no es posible mappear una clase abastracta.
        {
            CreateMap<UserDTO , Admin>(); //Mappeo de usuario a Admin
            CreateMap<UserDTO, Client>();  //Mappeo de usuario a Client
        }

    }
}
