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
            _config = config; //Hacemos la inyección para poder usar el appsettings.json.
            this._authenticationService = autenticacionService; //Inyectamos el autenticador.
            this._userService = userService; //Hacemos la inyección del servicio de usuario.
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            BaseResponse validarUsuarioResult = _authenticationService.ValidateUser(authenticationRequestBody); //El método post devolverá una Respuesta mockeada, alojada en los models.
            if (validarUsuarioResult.Message == "wrong username")
            {
                return BadRequest(validarUsuarioResult.Message); //Devolvemos la respuesta de error.
            }
            else if (validarUsuarioResult.Message == "wrong password")
            {
                return Unauthorized(); //Devolvemos un 403 Status code (sin autorización).
            }
            if (validarUsuarioResult.Result)
            {
                User? user = _userService.GetByUserName(authenticationRequestBody.UserName); //Se busca un usuario por su nombre.
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Creamos una secret key para hashearla dentro del Token.

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256); //Hasheamos la Secret Key + la Payload + el Header.

                var claimsForToken = new List<Claim>();                        //Creamos una lista de Claims (Requisitos) 
                claimsForToken.Add(new Claim("sub", user.Id.ToString()));       //Son piezas de informacíon necesarias para concretar la creación del Token y la autorización.
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("usertype", user.UserType.ToString()));

                var jwtSecurityToken = new JwtSecurityToken( //Creamos el token con todo lo necesario para que funcione.
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1), //Le damos una hora de validez al token, para que no se venza.
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken); //Escribimos el token mediante el método WriteToken().
                return Ok(tokenToReturn); //Devolvemos el TOKEN al pegarle al endpoint.
            }
            return BadRequest(); //Si no funciona, devolvemos un Bad Request (Status code 400).
        }
    }
}