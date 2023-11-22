CREATE DATABASE COMERCIOPANADERIA;
GO
USE COMERCIOPANADERIA;
GO
CREATE TABLE CATEGORIAS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(30) NOT NULL,
	Activo BIT NOT NULL default(1)
)
GO
CREATE TABLE MEDIDAS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(20) NOT NULL,
	Activo BIT NOT NULL default(1)
)
GO
CREATE TABLE FABRICANTES
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(40) NOT NULL,
	Activo BIT NOT NULL default(1)
)
GO
CREATE TABLE PRODUCTOS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo VARCHAR(8) NOT NULL,
    Nombre VARCHAR(40) NOT NULL,
    Descripcion VARCHAR(100),
    IdCategoria INT,
    IdFabricante INT,
    IdMedida INT,
    Precio DECIMAL(10, 2) NOT NULL,
    Activo BIT NOT NULL default(1)
)
GO
CREATE TABLE Stock
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT,
	Cantidad DECIMAL(10, 2),
	Activo BIT NOT NULL default(1)
);
go
CREATE TABLE StockHistorial
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT,
    CantidadAnterior DECIMAL(10, 2),-- la cantidad anterior
    CantidadNueva DECIMAL(10, 2),-- la cantidad ingresada por teclado
    FechaHoraRegistro DATETIME,
    Operacion VARCHAR(10), -- Puede ser "Ingreso" o "Egreso"
    Comentario VARCHAR(255), -- Comentario opcional para operaciones de egreso
	UsuarioId INT -- ID del usuario que realizó la operación
);
go
Create Table USUARIOS(
	ID int primary key not null identity (1,1),
	Usuario varchar(50) not null,
	Contraseña varchar(50) not null,
	TipoUsuario int,
	Activo bit not null default(1)
)
----------------------------------------------------------------------------------------------------

-- Inserción de datos en la tabla CATEGORIAS
INSERT INTO CATEGORIAS (Tipo)
VALUES
('PASTELERÍA'),
('PORCIONES'),
('GALLETERÍA'),
('SÁNDWICHES'),
('PANES'),
('PRE PIZZAS'),
('LÁCTEOS'),
('COTILLÓN'),
('BOMBONES'),
('ALFAJORES');

-- Inserción de datos en la tabla MEDIDAS
INSERT INTO MEDIDAS (Tipo)
VALUES
('KILOGRAMO'),
('UNIDAD'),
('GRAMOS'),
('DOCENA'),
('PORCION'),
('BARRA'),
('PAQUETE'),
('BOLSA');

-- Inserción de datos en la tabla FABRICANTES
INSERT INTO FABRICANTES (Nombre)
VALUES
('Fabricante 1'),
('Fabricante 2'),
('Fabricante 3');

-- Inserción de ejemplos de productos en la tabla PRODUCTOS con datos de categorías, medidas y fabricantes
INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, IdCategoria, IdFabricante, IdMedida, Precio)
VALUES
('PAN001', 'Pan Integral Multigrano', 'Pan de trigo integral con semillas', 5, 1, 1, 2.99),
('GAL001', 'Galletas de Avena', 'Deliciosas galletas de avena caseras', 3, 2, 2, 1.99),
('SAND001', 'Sándwich de Pollo', 'Sándwich de pollo con lechuga y tomate', 4, 3, 1, 4.50),
('PAN002', 'Pan de Centeno', 'Pan de centeno fresco', 5, 1, 1, 2.49),
('CAKE001', 'Torta de Chocolate', 'Torta de chocolate con crema y frutas', 1, 3, 3, 15.99),
('ALFA001', 'Alfajores de Dulce de Leche', 'Alfajores rellenos de dulce de leche', 6, 2, 2, 2.75),
('PAN003', 'Pan de Maíz', 'Pan de maíz recién horneado', 5, 1, 1, 2.29),
('CAKE002', 'Torta de Frutas', 'Torta de frutas variadas con crema', 1, 3, 3, 17.50),
('BOM001', 'Bombones de Chocolate', 'Bombones de chocolate surtidos', 8, 2, 2, 8.99),
('SAND002', 'Sándwich Vegetariano', 'Sándwich vegetariano con aguacate', 4, 3, 1, 5.00);

INSERT INTO Stock (IdProducto, Cantidad)
VALUES
  (1, 100),
  (2, 200),
  (3, 50),
  (4, 120),
  (5, 10),
  (6, 300),
  (7, 70),
  (8, 5);
