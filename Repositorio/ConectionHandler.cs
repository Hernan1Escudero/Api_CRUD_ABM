namespace Api_Penultima_Entrega.Repositorio
{
    public class ConectionHandler
    {
        public static string conectionString() {
            string conectionString = "Data Source=HERNAN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return conectionString;
        
        }
    }
}
