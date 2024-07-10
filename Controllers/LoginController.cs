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
        //Creamos constructor 
        public LoginController(IConfiguration config) 
        {
            _config = config;
        }

        //Asignamos el metodo con el que vamos a interactuar a la hora de enviar informacion
        [HttpPost(Name = "Login")]
        [AllowAnonymous]

        //Creamos el metodo para validar si el usuario existe o no.
        public IActionResult Login(UsuarioModel usuariologin)
        {
            //creamos una variable donde nos guarda los datos del usuario que digitan
            var usar = autenticar(usuariologin);
            //Definimos que los datos guardados coincida de lo contrario no nos genera token
            if (usar != null) {
                //crear Token
                var token = Generar(usar);

                return Ok("token: " + token);
            
            }
            return NotFound("Usuario no existe");

        }

        //Creamos un metodo 
        private UsuarioModel autenticar(UsuarioModel usuariologin) 
        {
            //Validamos que los datos ingresados sean iguales a los datos que tenemos constante en UsuarioConstante
            var actual = UsuarioConstante.usuario.FirstOrDefault( usar => usar.usuario.ToLower() == usuariologin.usuario.ToLower() 
            && usar.contrasena == usuariologin.contrasena );

            //Validamos que la variable tenga datos
            if (actual != null) {
                return actual;

            }
            return null;
        }

        //Creamos metodo para crear reclamaciones y crear el token
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
