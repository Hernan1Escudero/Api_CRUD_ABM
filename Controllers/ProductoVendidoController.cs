using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Api_Penultima_Entrega.Repositorio;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public void getProductosVendidos(long idUsuario) {

         ProductoVendidoHandler.obtenerProductosVendidos(idUsuario);
        }
    }
}
