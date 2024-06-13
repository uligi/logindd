namespace loginregistermenu.Models
{
    public class Pago
    {
        public int PagoID { get; set; }
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; } = new Pedido();
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public int MetodoPagoID { get; set; }
        public Metodo_Pago MetodoPago { get; set; } = new Metodo_Pago();
        public int EstadoPagoID { get; set; }
        public Estado_Pago EstadoPago { get; set; } = new Estado_Pago();
    }
}
