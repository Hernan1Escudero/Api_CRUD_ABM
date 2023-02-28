using Api_Penultima_Entrega.Modelos;
using Api_Penultima_Entrega.Repositorio;
using ConsoleApp4.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Net;
using System.Security;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
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


        [HttpPut]
        public HttpResponseMessage modificarUsuario(Usuario usuario) {
            try
            {
                UsuarioHandler.updateUsuario(usuario);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
        }

        [HttpGet("{idUsuario}")]
        public  Usuario traerUsuario(int idUsuario)
        {
            try
            {
                
                return UsuarioHandler.obtenerUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        [HttpGet("{idUsuario}/{contrasena}")]
        public  Usuario traerLogin( string idUsuario, string contrasena)
        {
            try
            {
                
                return UsuarioHandler.obtenerInicioDeSesion(idUsuario, contrasena);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
