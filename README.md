# logindd

-- Crear la base de datos
CREATE DATABASE sales_system;
GO

-- Usar la base de datos sales_system
USE sales_system;
GO

-- Crear la tabla Users
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Cedula NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL
);
GO

USE sales_system;
GO

-- Crear la tabla Productos
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NOT NULL,
    Precio DECIMAL(18, 2) NOT NULL,
    Stock INT NOT NULL
);
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,
    Posicion NVARCHAR(100) NOT NULL
);
GO


EXEC sp_rename 'Users', 'Usuarios';

-- Renombrar las columnas en la tabla Usuarios
EXEC sp_rename 'Usuarios.Name', 'Nombre', 'COLUMN';
EXEC sp_rename 'Usuarios.Cedula', 'Cedula', 'COLUMN';
EXEC sp_rename 'Usuarios.Email', 'Correo', 'COLUMN';
EXEC sp_rename 'Usuarios.Password', 'Contrasena', 'COLUMN';
EXEC sp_rename 'Usuarios.Role', 'Rol', 'COLUMN';