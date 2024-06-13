# logindd

-- Crear la base de datos
CREATE DATABASE sales_system;
GO

USE sales_system;
DROP TABLE IF EXISTS Empleados
DROP TABLE IF EXISTS Productos
DROP TABLE IF EXISTS Usuarios


-- Crear la base de datos
CREATE DATABASE sales_system;
GO

USE sales_system;

-- Crear tablas básicas de referencia primero

CREATE TABLE Provincia (
    ProvinciaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL
);

CREATE TABLE Canton (
    CantonID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    ProvinciaID INT NOT NULL,
    FOREIGN KEY (ProvinciaID) REFERENCES Provincia(ProvinciaID)
);

CREATE TABLE Distrito (
    DistritoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    CantonID INT NOT NULL,
    FOREIGN KEY (CantonID) REFERENCES Canton(CantonID)
);

USE sales_system;
CREATE TABLE Genero (
    GeneroID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Estado_Civil (
    EstadoCivilID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Estado_Persona (
    EstadoPersonaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Categoria (
    CategoriaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Descripcion TEXT
);

USE sales_system;
CREATE TABLE Tipo_Producto (
    TipoProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Metodo_Pago (
    MetodoPagoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Estado_Factura (
    EstadoFacturaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Estado_Pago (
    EstadoPagoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Estado_Pedido (
    EstadoPedidoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Tipo_Direccion (
    TipoDireccionID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Tipo_Usuario (
    TipoUsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Tipo_Correo (
    TipoCorreoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Tipo_Telefono (
    TipoTelefonoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Tipo_Transaccion (
    TipoTransaccionID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Envio_Estado (
    EnvioEstadoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

USE sales_system;
CREATE TABLE Puesto_Empleado (
    PuestoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);

-- Crear tabla Persona y Usuario
USE sales_system;
CREATE TABLE Persona (
    PersonaID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Apellido VARCHAR(255) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    GeneroID INT NOT NULL,
    EstadoCivilID INT NOT NULL,
    EstadoPersonaID INT NOT NULL,
    FOREIGN KEY (GeneroID) REFERENCES Genero(GeneroID),
    FOREIGN KEY (EstadoCivilID) REFERENCES Estado_Civil(EstadoCivilID),
    FOREIGN KEY (EstadoPersonaID) REFERENCES Estado_Persona(EstadoPersonaID)
);

USE sales_system;
CREATE TABLE Usuario (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    NombreUsuario VARCHAR(255) NOT NULL,
    Contraseña VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Telefono VARCHAR(20),
    TipoUsuarioID INT NOT NULL,
    PersonaID INT NOT NULL,
    FOREIGN KEY (TipoUsuarioID) REFERENCES Tipo_Usuario(TipoUsuarioID),
    FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID)
);

-- Crear tablas relacionadas con Producto y Ventas

USE sales_system;
CREATE TABLE Producto (
    ProductoID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Descripcion TEXT,
    Precio DECIMAL(10, 2) NOT NULL,
    CantidadEnStock INT NOT NULL,
    FechaIngreso DATE NOT NULL,
    CategoriaID INT NOT NULL,
    TipoProductoID INT NOT NULL,
    FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID),
    FOREIGN KEY (TipoProductoID) REFERENCES Tipo_Producto(TipoProductoID)
);



//******////


-- Crear tablas de Facturas
USE sales_system;
CREATE TABLE Facturas (
    FacturaID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NOT NULL,
    FechaEmision DATETIME NOT NULL,
    TotalFactura DECIMAL(10, 2) NOT NULL,
    EstadoFacturaID INT NOT NULL,
    MetodoPagoID INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID),
    FOREIGN KEY (EstadoFacturaID) REFERENCES Estado_Factura(EstadoFacturaID),
    FOREIGN KEY (MetodoPagoID) REFERENCES Metodo_Pago(MetodoPagoID)
);

USE sales_system;
CREATE TABLE DetalleFactura (
    DetalleFacturaID INT PRIMARY KEY IDENTITY(1,1),
    FacturaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);

-- Crear tablas de Pedidos y relacionadas
//*****//

//***//


-- Crear tabla de Carrito

USE sales_system;
CREATE TABLE Carrito (
    CarritoID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID)
);

-- Crear tabla de Reseñas

USE sales_system;
CREATE TABLE Reseñas (
    ReseñaID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT NOT NULL,
    ClienteID INT NOT NULL,
    Calificacion INT NOT NULL,
    Comentario TEXT,
    FechaReseña DATETIME NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID),
    FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID)
);

-- Crear tablas de Inventario y transacciones
//******///


-- Crear tablas de Direcciones, Teléfonos y Correos

USE sales_system;
CREATE TABLE Direcciones (
    DireccionID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    Ciudad VARCHAR(100) NOT NULL,
    Estado VARCHAR(100) NOT NULL,
    CodigoPostal VARCHAR(20) NOT NULL,
    Pais VARCHAR(100) NOT NULL,
    TipoDireccionID INT NOT NULL,
    FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID),
    FOREIGN KEY (TipoDireccionID) REFERENCES Tipo_Direccion(TipoDireccionID)
);

USE sales_system;
CREATE TABLE Telefono (
    TelefonoID INT PRIMARY KEY IDENTITY(1,1),
    PersonaID INT NOT NULL,
    TipoTelefonoID INT NOT NULL,
    NumeroTelefono VARCHAR(20) NOT NULL,
    FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID),
    FOREIGN KEY (TipoTelefonoID) REFERENCES Tipo_Telefono(TipoTelefonoID)
);

USE sales_system;
CREATE TABLE Correo (
    CorreoID INT PRIMARY KEY IDENTITY(1,1),
    PersonaID INT NOT NULL,
    TipoCorreoID INT NOT NULL,
    DireccionCorreo VARCHAR(255) NOT NULL,
    FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID),
    FOREIGN KEY (TipoCorreoID) REFERENCES Tipo_Correo(TipoCorreoID)
);

USE sales_system;
CREATE TABLE Detalle_Correo (
    DetalleCorreoID INT PRIMARY KEY IDENTITY(1,1),
    CorreoID INT NOT NULL,
    Detalle TEXT NOT NULL,
    FOREIGN KEY (CorreoID) REFERENCES Correo(CorreoID)
);

-- Crear tabla de Pagos
//***//


-- Crear tablas de Envios y estado de envios
//***//


-- Crear tablas de empleados y puestos
USE sales_system;
CREATE TABLE Empleado (
    EmpleadoID INT PRIMARY KEY IDENTITY(1,1),
    PersonaID INT NOT NULL,
    PuestoID INT NOT NULL,
    FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID),
    FOREIGN KEY (PuestoID) REFERENCES Puesto_Empleado(PuestoID)
);

//******////
USE sales_system;
CREATE TABLE Ventas (
    VentaID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NOT NULL,
    FechaVenta DATETIME NOT NULL,
    TotalVenta DECIMAL(10, 2) NOT NULL,
    FacturaID INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID),
    FOREIGN KEY (FacturaID) REFERENCES Facturas(FacturaID)
);

USE sales_system;
CREATE TABLE Detalle_Ventas (
    DetalleVentaID INT PRIMARY KEY IDENTITY(1,1),
    VentaID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (VentaID) REFERENCES Ventas(VentaID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);

USE sales_system;
CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY IDENTITY(1,1),
    ClienteID INT NOT NULL,
    FechaPedido DATETIME NOT NULL,
    EstadoPedidoID INT NOT NULL,
    TotalPedido DECIMAL(10, 2) NOT NULL,
    DireccionEnvioID INT NOT NULL,
    MetodoPagoID INT NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID),
    FOREIGN KEY (EstadoPedidoID) REFERENCES Estado_Pedido(EstadoPedidoID),
    FOREIGN KEY (DireccionEnvioID) REFERENCES Direcciones(DireccionID),
    FOREIGN KEY (MetodoPagoID) REFERENCES Metodo_Pago(MetodoPagoID)
);

USE sales_system;
CREATE TABLE Detalle_Pedido (
    DetallePedidoID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT NOT NULL,
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID),
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID)
);

USE sales_system;
CREATE TABLE Inventario (
    InventarioID INT PRIMARY KEY IDENTITY(1,1),
    ProductoID INT NOT NULL,
    Cantidad INT NOT NULL,
    FechaTransaccion DATETIME NOT NULL,
    TipoTransaccionID INT NOT NULL,
    EmpleadoID INT NOT NULL,
    FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID),
    FOREIGN KEY (TipoTransaccionID) REFERENCES Tipo_Transaccion(TipoTransaccionID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleado(EmpleadoID)
);

USE sales_system;
CREATE TABLE Pagos (
    PagoID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT NOT NULL,
    FechaPago DATETIME NOT NULL,
    Monto DECIMAL(10, 2) NOT NULL,
    MetodoPagoID INT NOT NULL,
    EstadoPagoID INT NOT NULL,
    FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID),
    FOREIGN KEY (MetodoPagoID) REFERENCES Metodo_Pago(MetodoPagoID),
    FOREIGN KEY (EstadoPagoID) REFERENCES Estado_Pago(EstadoPagoID)
);

USE sales_system;
CREATE TABLE Envios (
    EnvioID INT PRIMARY KEY IDENTITY(1,1),
    PedidoID INT NOT NULL,
    FechaEnvio DATETIME NOT NULL,
    FechaEntrega DATETIME,
    EstadoEnvioID INT NOT NULL,
    ProveedorEnvio VARCHAR(255) NOT NULL,
    NumeroSeguimiento VARCHAR(255),
    FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID),
    FOREIGN KEY (EstadoEnvioID) REFERENCES Envio_Estado(EnvioEstadoID)
);
-- Agregar relaciones faltantes

-- Relación entre Producto y Inventario
ALTER TABLE Inventario ADD CONSTRAINT FK_Inventario_ProductoID FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID);

-- Relación entre Usuario y Carrito
ALTER TABLE Carrito ADD CONSTRAINT FK_Carrito_ClienteID FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID);

-- Relación entre Producto y Detalle_Ventas
ALTER TABLE Detalle_Ventas ADD CONSTRAINT FK_DetalleVenta_ProductoID FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID);

-- Relación entre Facturas y Usuario
ALTER TABLE Facturas ADD CONSTRAINT FK_Facturas_ClienteID FOREIGN KEY (ClienteID) REFERENCES Usuario(UsuarioID);

-- Relación entre DetalleFactura y Producto
ALTER TABLE DetalleFactura ADD CONSTRAINT FK_DetalleFactura_ProductoID FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID);

-- Relación entre Detalle_Pedido y Producto
ALTER TABLE Detalle_Pedido ADD CONSTRAINT FK_DetallePedido_ProductoID FOREIGN KEY (ProductoID) REFERENCES Producto(ProductoID);

-- Relación entre Direcciones y Usuario
ALTER TABLE Direcciones ADD CONSTRAINT FK_Direcciones_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuario(UsuarioID);

-- Relación entre Telefono y Persona
ALTER TABLE Telefono ADD CONSTRAINT FK_Telefono_PersonaID FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID);

-- Relación entre Correo y Persona
ALTER TABLE Correo ADD CONSTRAINT FK_Correo_PersonaID FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID);

-- Relación entre Empleado y Persona
ALTER TABLE Empleado ADD CONSTRAINT FK_Empleado_PersonaID FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID);

-- Relación entre Envios y Pedido
ALTER TABLE Envios ADD CONSTRAINT FK_Envios_PedidoID FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID);

-- Relación entre Facturas y Metodo_Pago
ALTER TABLE Facturas ADD CONSTRAINT FK_Facturas_MetodoPagoID FOREIGN KEY (MetodoPagoID) REFERENCES Metodo_Pago(MetodoPagoID);

-- Relación entre Pagos y Pedido
ALTER TABLE Pagos ADD CONSTRAINT FK_Pagos_PedidoID FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID);

-- Relación entre Producto y Categoria
ALTER TABLE Producto ADD CONSTRAINT FK_Producto_CategoriaID FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID);

-- Relación entre Producto y Tipo_Producto
ALTER TABLE Producto ADD CONSTRAINT FK_Producto_TipoProductoID FOREIGN KEY (TipoProductoID) REFERENCES Tipo_Producto(TipoProductoID);


