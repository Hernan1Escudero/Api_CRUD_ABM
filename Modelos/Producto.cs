namespace Api_Penultima_Entrega.Modelos
{
    public class Producto
    {
        private long id;
        private decimal costo;
        private string descripcion;
        private decimal precioVenta;
        private int stock;
        private long idUsuario;

        
        public Producto()
        {

        }

        public long Id { get => id; set => id = value; }
        public decimal Costo { get => costo; set => costo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }



        public override string ToString()
        {
            return $"Id Producto: {Id} " + "\n"
            + $"Id Usuario:  {IdUsuario}" + "\n"
            + $"Stock: {Stock}" + "\n"
            + $"Costo: {Costo}" + "\n"
            + $"Precio de Venta: {PrecioVenta}" + "\n"
            + $"Descripcion: {Descripcion}" + "\n"
            + "------------------------------------";
        }
    }
}
