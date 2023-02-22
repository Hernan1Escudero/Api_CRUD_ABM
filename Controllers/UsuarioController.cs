using Api_Penultima_Entrega.Modelos;
using Api_Penultima_Entrega.Repositorio;
using ConsoleApp4.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPut]
        public void crearUsuario(Usuario usuario)
        {
            if (UsuarioHandler.updateUsuario(usuario) >= 1)
            {
                Console.WriteLine("se pudo modificar usuario");
            }
            else
            {
                Console.WriteLine("no se pudo modificar usuario ");
            }
            
        }
          
    }
}
