using Api_Penultima_Entrega.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Penultima_Entrega.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
 
        [HttpGet("ruta")]
        public string ObtenerSaludo()
        {
            return "hola";
        }

        [HttpGet("{parametro}")]
        public string ObtenerSaludo( string parametro)
        {
            return "hola  "+parametro;
        }
    }


}