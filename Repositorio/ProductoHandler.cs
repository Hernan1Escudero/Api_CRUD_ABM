using Api_Penultima_Entrega.Modelos;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Handlers
{
    internal class ProductoHandler
    {
        public static List<Producto> obtenerProductos(long id)  // en caso de querer obtener todos los productos con por ese id de usuario
        {

            List<Producto> productos = new List<Producto>();
            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           
            using (SqlConnection conection = new SqlConnection(conectionString))
            {

                SqlCommand ProductWithUserID = new SqlCommand($"\r\nselect * from [dbo].[Producto]\r\ninner join Usuario on\r\nProducto.IdUsuario = Usuario.Id\r\nwhere Usuario.Id = '{id}' ", conection);

                conection.Open();
                SqlDataReader reader = ProductWithUserID.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = reader.GetInt64(0);
                        producto.Descripcion = reader.GetString(1);// si quisiera ser mas especifico traeria el nombre del producto cargado pero me parecio mejor traer el producto en si  osea  sus valores 
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario = reader.GetInt64(5);

                        productos.Add(producto);
                    }

                }
                return productos;


            }

        }

        public static Producto obtenerProducto(long id) // para obtener un producto con su  id de producto
        {

            Producto producto = new Producto();
            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection conection = new SqlConnection(conectionString))
            {

                SqlCommand ProductWithUserID = new SqlCommand($"select * from Producto\r\nwhere id= '{id}' ", conection);

                conection.Open();
                SqlDataReader reader = ProductWithUserID.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        producto.Id = reader.GetInt64(0);
                        producto.Descripcion = reader.GetString(1);// si quisiera ser mas especifico traeria el nombre del producto cargado pero me parecio mejor traer el producto en si  osea  sus valores 
                        producto.Costo = reader.GetDecimal(2);
                        producto.PrecioVenta = reader.GetDecimal(3);
                        producto.Stock = reader.GetInt32(4);
                        producto.IdUsuario = reader.GetInt64(5);

                      
                    }

                }
                return producto;


            }

        }



        public static int crearProducto(Producto producto)
        {

            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Producto](Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" + "VALUES(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)", conection);

                command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@Costo", producto.Costo);
                command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
                command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                return command.ExecuteNonQuery();
            }
        }
        public static int eliminarProducto(long id)
        {

            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand command = new SqlCommand("delete from dbo.Producto\r\nwhere Id =@id", conection);
                command.Parameters.AddWithValue(@"id", id);

                return command.ExecuteNonQuery();
            }
        }


        public static int updateStockProducto(long id, int cantidadVendidos)
        {
             Producto producto = obtenerProducto(id);
             producto.Stock -= cantidadVendidos;
            
            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[Producto] SET [Stock] = @Stock WHERE id = @Id", conection);

                command.Parameters.AddWithValue("@Id", producto.Id);
                command.Parameters.AddWithValue("@Stock", producto.Stock);
               

                return command.ExecuteNonQuery();
            }
        }
    }
}
