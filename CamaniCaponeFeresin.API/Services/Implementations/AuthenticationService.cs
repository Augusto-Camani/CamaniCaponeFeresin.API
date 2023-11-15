using CamaniCaponeFeresin.API.Data.Repositories.Interfaces;
using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;

namespace CamaniCaponeFeresin.API.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse ValidateUser(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password)) //Verificamos que el usuario y la contraseña no sean NULAS.
                return null;

            return _userRepository.ValidateUser(authenticationRequest);
        }
    }
}
