using Microsoft.EntityFrameworkCore;
using loginregistermenu.Models;

namespace loginregistermenu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Genero> Generos { get; set; }
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
        public DbSet<Tipo_Usuario> TiposUsuario { get; set; }
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
        public DbSet<Envio_Estado> EnvioEstado { get; set; }
        public DbSet<Envio_Estado> EnvioEstados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar relaciones
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Persona)
                .WithMany()
                .HasForeignKey(e => e.PersonaID);

            // Empleado - Puesto
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Puesto)
                .WithMany()
                .HasForeignKey(e => e.PuestoID);

            // Persona - Genero
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.Genero)
                .WithMany()
                .HasForeignKey(p => p.GeneroID);

            // Persona - EstadoCivil
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.EstadoCivil)
                .WithMany()
                .HasForeignKey(p => p.EstadoCivilID);

            // Persona - EstadoPersona
            modelBuilder.Entity<Persona>()
                .HasOne(p => p.EstadoPersona)
                .WithMany()
                .HasForeignKey(p => p.EstadoPersonaID);

            // Pedido - Usuario (Cliente)
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteID);

            // Pedido - EstadoPedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.EstadoPedido)
                .WithMany()
                .HasForeignKey(p => p.EstadoPedidoID);

            // Pedido - DireccionEnvio
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.DireccionEnvio)
                .WithMany()
                .HasForeignKey(p => p.DireccionEnvioID);

            // Pedido - MetodoPago
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.MetodoPago)
                .WithMany()
                .HasForeignKey(p => p.MetodoPagoID);

            // Detalle_Pedido - Pedido
            modelBuilder.Entity<Detalle_Pedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany()
                .HasForeignKey(dp => dp.PedidoID);

            // Detalle_Pedido - Producto
            modelBuilder.Entity<Detalle_Pedido>()
                .HasOne(dp => dp.Producto)
                .WithMany()
                .HasForeignKey(dp => dp.ProductoID);

            // Factura - Usuario (Cliente)
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.ClienteID);

            // Factura - EstadoFactura
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.EstadoFactura)
                .WithMany()
                .HasForeignKey(f => f.EstadoFacturaID);

            // Factura - MetodoPago
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.MetodoPago)
                .WithMany()
                .HasForeignKey(f => f.MetodoPagoID);

            // Detalle_Factura - Factura
            modelBuilder.Entity<Detalle_Factura>()
                .HasOne(df => df.Factura)
                .WithMany()
                .HasForeignKey(df => df.FacturaID);

            // Detalle_Factura - Producto
            modelBuilder.Entity<Detalle_Factura>()
                .HasOne(df => df.Producto)
                .WithMany()
                .HasForeignKey(df => df.ProductoID);

            // Inventario - Producto
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Producto)
                .WithMany()
                .HasForeignKey(i => i.ProductoID);

            // Inventario - TipoTransaccion
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.TipoTransaccion)
                .WithMany()
                .HasForeignKey(i => i.TipoTransaccionID);

            // Inventario - Empleado
            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Empleado)
                .WithMany()
                .HasForeignKey(i => i.EmpleadoID);

            // Pago - Pedido
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Pedido)
                .WithMany()
                .HasForeignKey(p => p.PedidoID);

            // Pago - MetodoPago
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.MetodoPago)
                .WithMany()
                .HasForeignKey(p => p.MetodoPagoID);

            // Pago - EstadoPago
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.EstadoPago)
                .WithMany()
                .HasForeignKey(p => p.EstadoPagoID);

            // Envio - Pedido
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Pedido)
                .WithMany()
                .HasForeignKey(e => e.PedidoID);

            // Envio - EstadoEnvio
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.EstadoEnvio)
                .WithMany()
                .HasForeignKey(e => e.EstadoEnvioID);

            // Carrito - Usuario (Cliente)
            modelBuilder.Entity<Carrito>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteID);

            // Reseña - Producto
            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Producto)
                .WithMany()
                .HasForeignKey(r => r.ProductoID);

            // Reseña - Usuario (Cliente)
            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteID);

            // Direccion - Usuario
            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.Usuario)
                .WithMany(u => u.Direcciones)
                .HasForeignKey(d => d.UsuarioID);

            // Direccion - TipoDireccion
            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.TipoDireccion)
                .WithMany()
                .HasForeignKey(d => d.TipoDireccionID);

            // Telefono - Persona
            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.Persona)
                .WithMany(p => p.Telefonos)
                .HasForeignKey(t => t.PersonaID);

            // Telefono - TipoTelefono
            modelBuilder.Entity<Telefono>()
                .HasOne(t => t.TipoTelefono)
                .WithMany()
                .HasForeignKey(t => t.TipoTelefonoID);

            // Correo - Persona
            modelBuilder.Entity<Correo>()
                .HasOne(c => c.Persona)
                .WithMany(p => p.Correos)
                .HasForeignKey(c => c.PersonaID);

            // Correo - TipoCorreo
            modelBuilder.Entity<Correo>()
                .HasOne(c => c.TipoCorreo)
                .WithMany()
                .HasForeignKey(c => c.TipoCorreoID);

            // Detalle_Correo - Correo
            modelBuilder.Entity<Detalle_Correo>()
                .HasOne(dc => dc.Correo)
                .WithMany()
                .HasForeignKey(dc => dc.CorreoID);


        }
    }
}
