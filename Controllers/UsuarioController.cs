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
            if (UsuarioHandler.crearUsuario(usuario) >= 1)
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


        [HttpGet("{nombreUsuario}/{contrasena}")]
        public  Usuario traerLogin( string nombreUsuario, string contrasena)
        {
            try
            {
                
                return UsuarioHandler.obtenerInicioDeSesion(nombreUsuario, contrasena);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
