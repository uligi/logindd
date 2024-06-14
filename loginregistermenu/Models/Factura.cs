namespace loginregistermenu.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int EstadoFacturaID { get; set; }
        public int MetodoPagoID { get; set; }

        public Usuario Cliente { get; set; } = new Usuario();
        public Estado_Factura EstadoFactura { get; set; } = new Estado_Factura();
        public Metodo_Pago MetodoPago { get; set; } = new Metodo_Pago();
        public ICollection<Detalle_Factura> DetallesFactura { get; set; } = new List<Detalle_Factura>();
    }
}
