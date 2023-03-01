using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using Api_Penultima_Entrega.Repositorio;
using Api_Penultima_Entrega.Modelos;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<ProductoVendido> getProductosVendidos(long idUsuario) {

         return ProductoVendidoHandler.obtenerProductosVendidos(idUsuario);
        }
    }
}
