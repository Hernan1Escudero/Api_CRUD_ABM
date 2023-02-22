﻿using Api_Penultima_Entrega.Modelos;
using Api_Penultima_Entrega.Repositorio;
using ConsoleApp4.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Api_Penultima_Entrega.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void CrearProducto(Producto producto){

            
            if (ProductoHandler.crearProducto(producto) >= 1)
            {
                Console.WriteLine("se pudo crear");
            }
            else
            {
                Console.WriteLine("no se pudo crear ");
            }
        }


        [HttpDelete("{id}")]

        public void eliminarPorducto(long id)
        {
            if (ProductoHandler.eliminarProducto(id) >= 1)
            {
                Console.WriteLine("se pudo eliminar");
            }
            else
            {
                Console.WriteLine("no se pudo eliminar");
            }
            

        }

        [HttpPut]
        public void UpdateStock(long id, int cantidadVendidos)
        {
            if (ProductoHandler.updateStockProducto( id,cantidadVendidos) >= 1)
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
