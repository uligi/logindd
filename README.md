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
