using Inalambria.PruebaTecnica.Convertidor;
using Inalambria.PruebaTecnica.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inalambria.PruebaTecnica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PruebaTecnicaController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;

        public PruebaTecnicaController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Prueba Tecnica")]
        [Authorize]
        public IActionResult Post([FromBody] ValorEntradaModel solicitud)
        {
            try
            {
                ConvertirNumero convertirNumero = new ConvertirNumero();
                ValorSalidaModel salida = new ValorSalidaModel();
                if (!long.TryParse(solicitud.Valor, out long valor) || valor < 0 || valor > 999999999999) {
                    return BadRequest("Error al convertir numero, solo admite de 0 a 999999999999 y numeros enteros");
                }
                salida.NumeroEnLetras = convertirNumero.ConvertirATexto(valor);
                return Ok(salida);

            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
     
        }

    }
}
