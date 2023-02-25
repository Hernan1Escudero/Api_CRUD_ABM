using Api_Penultima_Entrega.Modelos;
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
            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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

        public static long InsertarVenta(Venta venta)
        {

            string conectionString = "Data Source=DESKTOP-9SVG7S5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand commandVenta = new SqlCommand("Insert into Venta(Comentarios, IdUsuario)" +
                    "values (@Comentarios,@IdUsuario);Select @@IDENTITY ", conection);

                commandVenta.Parameters.AddWithValue("@Comentarios", venta.Comentario);
                commandVenta.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                commandVenta.ExecuteScalar();


                return Convert.ToInt64(commandVenta.ExecuteScalar());
            }

            

        }

        public static void cargarVenta(long id, List<Producto> productosVendidos) {

            string conectionString = "Data Source=DESKTOP-9SVG7S5;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
          foreach (Producto producto in productosVendidos){
               using (SqlConnection conection = new SqlConnection(conectionString))
                {
              
                conection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Producto](Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" + "VALUES(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)", conection);
              
                
                    command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                }

            }


        }
    }
}
