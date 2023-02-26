using Api_Penultima_Entrega.Modelos;
using ConsoleApp4.Handlers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Penultima_Entrega.Repositorio
{
    internal class VentaHandler
    {
        public static List<Venta> obtenerVentas(long id)
        {
            List<Venta> ventas = new List<Venta>();
            string conectionString = ConectionHandler.conectionString();

            using (SqlConnection conection = new SqlConnection(conectionString))
            {

                SqlCommand ProductWithUserID = new SqlCommand($"select * from [dbo].[venta]\r\ninner join Usuario on\r\nventa.IdUsuario = Usuario.Id\r\nwhere Usuario.Id ='{id}' ", conection);

                conection.Open();
                SqlDataReader reader = ProductWithUserID.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta venta = new Venta();
                        venta.Id = reader.GetInt64(0);
                        venta.Comentario = reader.GetString(1);
                        venta.IdUsuario = reader.GetInt64(2);


                        ventas.Add(venta);
                    }

                }
                return ventas;


            }

        }

        public static void InsertarVenta(Venta venta)
        {
            string conectionString = ConectionHandler.conectionString();
;            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand commandVenta = new SqlCommand("INSERT INTO [dbo].[Venta] ([Comentarios] ,[IdUsuario])VALUES (@Comentarios,@IdUsuario); Select @@IDENTITY ", conection);

                commandVenta.Parameters.AddWithValue("@Comentarios", venta.Comentario);
                commandVenta.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                commandVenta.ExecuteNonQuery();


                //return Convert.ToInt64(commandVenta.ExecuteScalar());
            }

        }

        public static void cargarVenta(long id, List<Producto> productosVendidos) {

           foreach (Producto producto in productosVendidos)
            {
                Venta venta = new Venta();
                Int64 productId = producto.Id;
                Int64 productUser = producto.IdUsuario;
                string product = producto.Descripcion;
                int productStock = (producto.Stock);
                venta.Comentario = $"se vendieron unidades:{productStock} del producto: {product} ";
                venta.IdUsuario = productUser;

                ProductoVendido productoVendido = new ProductoVendido();
                productoVendido.IdProducto = productId;
                productoVendido.IdVenta = id;
                productoVendido.Stock = productStock;

                InsertarVenta(venta);
                ProductoVendidoHandler.InsertarProductoVendido( productoVendido);
                ProductoHandler.updateStockProducto(productId,productStock);
                /* using (SqlConnection conection = new SqlConnection(conectionString))
                {
                        
                    conection.Open();
                    //VentaHandler.InsertarVenta()
  
                    SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Producto](Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" + "VALUES(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)", conection);

                    command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);


                } */

            }

        }
    }
}
