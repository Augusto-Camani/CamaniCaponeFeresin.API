using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;

namespace CamaniCaponeFeresin.API.Services.Interfaces
{
    public interface IAuthenticationService
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}
