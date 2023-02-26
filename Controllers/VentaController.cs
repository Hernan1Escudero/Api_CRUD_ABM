using Api_Penultima_Entrega.Modelos;
using Api_Penultima_Entrega.Repositorio;
using ConsoleApp4.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {

        [HttpPost("{id}")]
        public void cargarVenta(long id, List<Producto> productos)
        {
            VentaHandler.cargarVenta(id, productos);
            Console.WriteLine("Fin cargar venta");
        }

       
     }

 }
