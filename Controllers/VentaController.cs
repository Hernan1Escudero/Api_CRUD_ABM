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
        [HttpPost("{id}")]
        public HttpResponseMessage cargarVenta(long id, List<Producto> productos)
        {
            try
            {
                VentaHandler.cargarVenta(id, productos);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch ( Exception ex) {

                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            
            
        }

        [HttpGet("{id}")]
        public HttpResponseMessage traerVenta(long id)
        {

            try
            {
                VentaHandler.obtenerVenta(id);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }

        }
    }
 }
