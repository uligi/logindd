using Microsoft.EntityFrameworkCore;
using loginregistermenu.Models;

namespace loginregistermenu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Estado_Civil> EstadoCiviles { get; set; }
        public DbSet<Estado_Persona> EstadoPersonas { get; set; }
        public DbSet<Puesto_Empleado> PuestosEmpleados { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Metodo_Pago> MetodosPago { get; set; }
        public DbSet<Estado_Factura> EstadosFactura { get; set; }
        public DbSet<Estado_Pago> EstadosPago { get; set; }
        public DbSet<Estado_Pedido> EstadosPedido { get; set; }
        public DbSet<Tipo_Producto> TiposProducto { get; set; }
        public DbSet<Tipo_Direccion> TiposDireccion { get; set; }
        public DbSet<Tipo_Correo> TiposCorreo { get; set; }
        public DbSet<Tipo_Telefono> TiposTelefono { get; set; }
        public DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public DbSet<Tipo_Transaccion> TiposTransaccion { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Detalle_Factura> DetallesFactura { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Detalle_Pedido> DetallesPedido { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Correo> Correos { get; set; }
        public DbSet<Detalle_Correo> DetallesCorreo { get; set; }
        public DbSet<Envio_Estado> EnvioEstados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relaciones
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Persona)
                .WithMany()
                .HasForeignKey(e => e.PersonaID);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Puesto)
                .WithMany()
                .HasForeignKey(e => e.PuestoID);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.GeneroID);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.EstadoCivil)
                .WithMany()
                .HasForeignKey(p => p.EstadoCivilID);

            modelBuilder.Entity<Persona>()
                .HasOne(p => p.EstadoPersona)
                .WithMany()
                .HasForeignKey(p => p.EstadoPersonaID);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteID);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.EstadoPedido)
                .WithMany()
                .HasForeignKey(p => p.EstadoPedidoID);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.DireccionEnvio)
                .WithMany()
                .HasForeignKey(p => p.DireccionEnvioID);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.MetodoPago)
                .WithMany()
                .HasForeignKey(p => p.MetodoPagoID);

            modelBuilder.Entity<Detalle_Pedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany()
                .HasForeignKey(dp => dp.PedidoID);

            modelBuilder.Entity<Detalle_Pedido>()
                .HasOne(dp => dp.Producto)
                .WithMany()
                .HasForeignKey(dp => dp.ProductoID);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.ClienteID);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.EstadoFactura)
                .WithMany()
                .HasForeignKey(f => f.EstadoFacturaID);

            modelBuilder.Entity<Factura>()
                .HasOne(f => f.MetodoPago)
                .WithMany()
                .HasForeignKey(f => f.MetodoPagoID);

            modelBuilder.Entity<Detalle_Factura>()
                .HasOne(df => df.Factura)
                .WithMany(f => f.DetallesFactura)
                .HasForeignKey(df => df.FacturaID);

            modelBuilder.Entity<Detalle_Factura>()
                .HasOne(df => df.Producto)
                .WithMany()
                .HasForeignKey(df => df.ProductoID);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Producto)
                .WithMany()
                .HasForeignKey(i => i.ProductoID);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.TipoTransaccion)
                .WithMany()
                .HasForeignKey(i => i.TipoTransaccionID);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Empleado)
                .WithMany()
                .HasForeignKey(i => i.EmpleadoID);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Pedido)
                .WithMany()
                .HasForeignKey(p => p.PedidoID);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.MetodoPago)
                .WithMany()
                .HasForeignKey(p => p.MetodoPagoID);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.EstadoPago)
                .WithMany()
                .HasForeignKey(p => p.EstadoPagoID);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Pedido)
                .WithMany()
                .HasForeignKey(e => e.PedidoID);

            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EstadoEnvio)
                .WithMany()
                .HasForeignKey(e => e.EstadoEnvioID);

            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteID);

            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Producto)
                .WithMany()
                .HasForeignKey(r => r.ProductoID);

            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteID);

            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Direcciones)
                .HasForeignKey(d => d.UsuarioID);

            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.TipoDireccion)
                .WithMany()
                .HasForeignKey(d => d.TipoDireccionID);

            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Persona)
                .WithMany(p => p.Telefonos)
                .HasForeignKey(t => t.PersonaID);

            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.TipoTelefono)
                .WithMany()
                .HasForeignKey(t => t.TipoTelefonoID);

            modelBuilder.Entity<Correo>()
                .HasOne(c => c.Persona)
                .WithMany(p => p.Correos)
                .HasForeignKey(c => c.PersonaID);

            modelBuilder.Entity<Correo>()
                .HasOne(c => c.TipoCorreo)
                .WithMany()
                .HasForeignKey(c => c.TipoCorreoID);

            modelBuilder.Entity<Detalle_Correo>()
                .HasKey(dc => dc.DetalleCorreoID);

            modelBuilder.Entity<Detalle_Correo>()
                .HasOne(dc => dc.Correo)
                .WithMany(c => c.DetallesCorreo)
                .HasForeignKey(dc => dc.CorreoID);

            modelBuilder.Entity<Detalle_Factura>()
                .HasKey(dc => dc.DetalleFacturaID);

            modelBuilder.Entity<Detalle_Factura>()
                .HasOne(df => df.Factura)
                .WithMany(f => f.DetallesFactura)
                .HasForeignKey(df => df.FacturaID);

            modelBuilder.Entity<Detalle_Factura>()
                .HasOne(df => df.Producto)
                .WithMany()
                .HasForeignKey(df => df.ProductoID);

            modelBuilder.Entity<Detalle_Pedido>()
                .HasKey(dc => dc.DetallePedidoID);

            modelBuilder.Entity<Envio_Estado>()
                .HasKey(dc => dc.EnvioEstadoID);

            modelBuilder.Entity<Estado_Civil>()
                .HasKey(dc => dc.EstadoCivilID);

            modelBuilder.Entity<Estado_Factura>()
                .HasKey(dc => dc.EstadoFacturaID);

            modelBuilder.Entity<Estado_Pago>()
                .HasKey(dc => dc.EstadoPagoID);

            modelBuilder.Entity<Estado_Pedido>()
                .HasKey(dc => dc.EstadoPedidoID);

            modelBuilder.Entity<Estado_Persona>()
                .HasKey(dc => dc.EstadoPersonaID);

            modelBuilder.Entity<Metodo_Pago>()
                .HasKey(dc => dc.MetodoPagoID);

            modelBuilder.Entity<Puesto_Empleado>()
                .HasKey(dc => dc.PuestoID);

            modelBuilder.Entity<Tipo_Correo>()
                .HasKey(dc => dc.TipoCorreoID);

            modelBuilder.Entity<Tipo_Direccion>()
                .HasKey(dc => dc.TipoDireccionID);

            modelBuilder.Entity<Tipo_Producto>()
                .HasKey(dc => dc.TipoProductoID);

            modelBuilder.Entity<Tipo_Telefono>()
                .HasKey(dc => dc.TipoTelefonoID);

            modelBuilder.Entity<Tipo_Transaccion>()
                .HasKey(dc => dc.TipoTransaccionID);

            modelBuilder.Entity<Tipo_Usuario>()
                .ToTable("Tipo_Usuario")  // Especifica el nombre de la tabla aquí
                .HasKey(dc => dc.TipoUsuarioID);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuarioID);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithMany()
                .HasForeignKey(u => u.PersonaID);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Tipo_Usuario)
                .WithMany()
                .HasForeignKey(u => u.TipoUsuarioID);
        }
    }
}
