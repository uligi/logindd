namespace loginregistermenu.Models
{
    public class Envio

    {
        public int EnvioID { get; set; }
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; } = new Pedido();
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int EstadoEnvioID { get; set; }
        public Envio_Estado EstadoEnvio { get; set; } = new Envio_Estado();
        public string ProveedorEnvio { get; set; } = string.Empty;
        public string NumeroSeguimiento { get; set; } = string.Empty;
    }
}
