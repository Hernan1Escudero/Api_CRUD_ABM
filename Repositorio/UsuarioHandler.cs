using Api_Penultima_Entrega.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Penultima_Entrega.Repositorio
{
    internal class UsuarioHandler
    {
        public static Usuario obtenerUsuario(int id)//Get usuario
        {
            // en como recibe un numero asumo que es el ID y como es unico solo debo traer un solo usuario
            Usuario usuario = new Usuario();
            string conectionString = ConectionHandler.conectionString();
            using (SqlConnection conection = new SqlConnection(conectionString))
            {

                SqlCommand ProductWithUserID = new SqlCommand($"select * from [dbo].[Usuario] where id = '{id}' ", conection);

                conection.Open();
                SqlDataReader reader = ProductWithUserID.ExecuteReader();

                if (reader.HasRows)
                { 
                    while (reader.Read())
                    {

                        usuario.Id = reader.GetInt64(0);
                        usuario.Nombre = reader.GetString(1);// si quisiera ser mas especifico traeria el nombre del usuario cargado pero me parecio mejor traer el producto en si  osea  sus valores  
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Contraseña = reader.GetString(4);
                        usuario.Mail = reader.GetString(5);

                    }


                }
                return usuario;


            }


        }
      
        public static Usuario obtenerInicioDeSesion(string usuario, string contraseña)//Get Login
        { // en este caso tambien traigo un solo usuario  ya que es por contraseña y nombre 
            Usuario Login = new Usuario();
            string conectionString = ConectionHandler.conectionString();
            using (SqlConnection conection = new SqlConnection(conectionString))
            {

                SqlCommand ProductWithUserID = new SqlCommand($"select * from [dbo].[Usuario] where NombreUsuario = '{usuario}' and Contraseña='{contraseña}' ", conection);

                conection.Open();
                SqlDataReader reader = ProductWithUserID.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Login.Id = reader.GetInt64(0);
                        Login.Nombre = reader.GetString(1);// si quisiera ser mas especifico traeria el nombre del usuario cargado pero me parecio mejor traer el producto en si  osea  sus valores  
                        Login.Apellido = reader.GetString(2);
                        Login.NombreUsuario = reader.GetString(3);
                        Login.Contraseña = reader.GetString(4);
                        Login.Mail = reader.GetString(5);


                    }

                }
                return Login;


            }

        }

        public static int crearUsuario(Usuario usuario)//Crear Usuario
        {

            string conectionString = ConectionHandler.conectionString();

            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Usuario]([Nombre],[Apellido],[NombreUsuario] ,[Contraseña],[Mail])"
                +"VALUES(@Nombre,@Apellido, @NombreUsuario, @Contraseña, @Mail)", conection);

                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@Mail", usuario.Mail);

                return command.ExecuteNonQuery();
            }
        }


        public static int updateUsuario( Usuario usuario)//Modificar Usuario
        {

            string conectionString = ConectionHandler.conectionString();
            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand command = new SqlCommand($"UPDATE [dbo].[Usuario] SET[Nombre] =@Nombre,[Apellido] = @Apellido,[NombreUsuario] = @NombreUsuario,[Contraseña] = @Contraseña,[Mail] = @Mail WHERE id =@id", conection);
                
                command.Parameters.AddWithValue("@id",usuario.Id);
                command.Parameters.AddWithValue( "@Nombre", usuario.Nombre );
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@Mail", usuario.Mail);
                

                return command.ExecuteNonQuery();
            }
        }

        public static int eliminarUsuario(long id)//Eliminar Usuario
        {

            string conectionString = ConectionHandler.conectionString();
            using (SqlConnection conection = new SqlConnection(conectionString))
            {
                conection.Open();
                SqlCommand command = new SqlCommand("delete from dbo.Usuario where Id =@id", conection);
                command.Parameters.AddWithValue(@"id", id);

                return command.ExecuteNonQuery();
            }
        }


    }
}
