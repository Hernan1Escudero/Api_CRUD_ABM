namespace Api_Penultima_Entrega.Modelos
{
    public class Venta
    {
        private long id;
        private string comentario;
        private long idUsuario;

        public long Id { get => id; set => id = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }

        public Venta(long id, string comentario, long idUsuario)
        {
            Id = id;
            Comentario = comentario;
            IdUsuario = idUsuario;
        }
        public Venta()
        {

        }
    }
}
