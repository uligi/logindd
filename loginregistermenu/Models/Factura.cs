namespace loginregistermenu.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int ClienteID { get; set; }
        public Usuario Cliente { get; set; } = new Usuario();
        public DateTime FechaEmision { get; set; }
        public decimal TotalFactura { get; set; }
        public int EstadoFacturaID { get; set; }
        public Estado_Factura EstadoFactura { get; set; } = new Estado_Factura();
        public int MetodoPagoID { get; set; }
        public Metodo_Pago MetodoPago { get; set; } = new Metodo_Pago();
    }
}
