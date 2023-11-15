using CamaniCaponeFeresin.API.Entities;
using CamaniCaponeFeresin.API.Models;
using CamaniCaponeFeresin.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConsultaAlumnos.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        public AuthenticationController(IConfiguration config, IAuthenticationService autenticacionService, IUserService userService)
        {
            _config = config; //Hacemos la inyección para poder usar el appsettings.json
            this._authenticationService = autenticacionService;
            this._userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            BaseResponse validarUsuarioResult = _authenticationService.ValidateUser(authenticationRequestBody);
            if (validarUsuarioResult.Message == "wrong email")
            {
                return BadRequest(validarUsuarioResult.Message);
            }
            else if (validarUsuarioResult.Message == "wrong password")
            {
                return Unauthorized();
            }
            if (validarUsuarioResult.Result)
            {
                User? user = _userService.GetByUserName(authenticationRequestBody.UserName);
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.Id.ToString()));
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("usertype", user.UserType.ToString()));

                var jwtSecurityToken = new JwtSecurityToken(
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            return BadRequest();
        }
    }
}