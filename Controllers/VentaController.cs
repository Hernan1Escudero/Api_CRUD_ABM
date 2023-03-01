using Api_Penultima_Entrega.Modelos;
using Api_Penultima_Entrega.Repositorio;
using ConsoleApp4.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("{idUsuario}")]
        public HttpResponseMessage cargarVenta(long idUsuario, List<Producto> productos)
        {
            try
            {
                VentaHandler.cargarVenta(idUsuario, productos);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch ( Exception ex) {

                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            
            
        }

        [HttpGet("{idUsuario}")]
        public Venta traerVenta(long idUsuario)
        {

            try
            {
                
                return VentaHandler.obtenerVenta(idUsuario);
            }
            catch (Exception ex)
            {

                return new Venta();
            }

        }
    }
 }
