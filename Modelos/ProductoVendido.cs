namespace Api_Penultima_Entrega.Modelos
{
    public class ProductoVendido
    {

        private long id;
        private int stock;
        private long idProducto;
        private long idVenta;

        public long Id { get => id; set => id = value; }
        public int Stock { get => stock; set => stock = value; }
        public long IdProducto { get => idProducto; set => idProducto = value; }
        public long IdVenta { get => idVenta; set => idVenta = value; }

        public ProductoVendido(long id, int stock, long idProducto, long idVenta)
        {
            Id = id;
            Stock = stock;
            IdProducto = idProducto;
            IdVenta = idVenta;
        }
        public ProductoVendido()
        {

        }
    }
}
