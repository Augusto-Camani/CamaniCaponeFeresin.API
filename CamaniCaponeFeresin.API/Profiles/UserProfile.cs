using AutoMapper;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();  
        }

    }
}
