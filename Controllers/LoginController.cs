using Inalambria.PruebaTecnica.Constant;
using Inalambria.PruebaTecnica.Convertidor;
using Inalambria.PruebaTecnica.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Inalambria.PruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
       

        private readonly IConfiguration _config;
        public LoginController(IConfiguration config) 
        {
            _config = config;
        }


        [HttpPost(Name = "Login")]
        [AllowAnonymous]
        public IActionResult Login(UsuarioModel usuariologin)
        {
            var usar = autenticar(usuariologin);
            if (usar != null) {
                //crear Token
                var token = Generar(usar);

                return Ok(token);
            
            }
            return NotFound("Usuario no existe");

        }

        private UsuarioModel autenticar(UsuarioModel usuariologin) 
        {
            var actual = UsuarioConstante.usuario.FirstOrDefault( usar => usar.usuario.ToLower() == usuariologin.usuario.ToLower() 
            && usar.contrasena == usuariologin.contrasena );

            if (actual != null) {
                return actual;

            }
            return null;
        }

        private string Generar(UsuarioModel usua) {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //Creamos las reclamaciones
            var reclamaciones = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usua.usuario),
            };
            //Creamos el token

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                reclamaciones,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
