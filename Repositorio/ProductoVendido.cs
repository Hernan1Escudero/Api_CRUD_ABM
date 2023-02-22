﻿using Api_Penultima_Entrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Penultima_Entrega.Repositorio
{
    internal class ProductoVendidoHandler
    {
        public static List<ProductoVendido> obtenerProductosVendidos(long id)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection conection = new SqlConnection(conectionString))
            {

                SqlCommand ProductWithUserID = new SqlCommand($"select * from [dbo].[ProductoVendido]\r\ninner join Usuario on\r\nProductovendido.IdVenta = Usuario.Id\r\nwhere Usuario.Id ='{id}' ", conection);

                conection.Open();
                SqlDataReader reader = ProductWithUserID.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoVendido = new ProductoVendido();
                        productoVendido.Id = reader.GetInt64(0);
                        productoVendido.Stock = reader.GetInt32(1);
                        productoVendido.IdProducto = reader.GetInt64(2);
                        productoVendido.IdVenta = reader.GetInt64(3);


                        productosVendidos.Add(productoVendido);
                    }

                }
                return productosVendidos;


            }

        }

    }
}