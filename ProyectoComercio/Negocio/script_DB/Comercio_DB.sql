-- Crea la base de datos
CREATE DATABASE COMERCIOPANADERIA;
GO

-- Usa la base de datos
USE COMERCIOPANADERIA;
GO

-- Tabla para almacenar información de Categorías
CREATE TABLE CATEGORIAS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(30) NOT NULL
);

-- Tabla para almacenar información de Medidas
CREATE TABLE MEDIDAS
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Tipo VARCHAR(20) NOT NULL
);

-- Tabla para almacenar información de Fabricantes
CREATE TABLE FABRICANTES
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(40) NOT NULL
);

-- Tabla para almacenar información de Sucursales
CREATE TABLE SUCURSALES
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(40) NOT NULL,
    Direccion VARCHAR(120) NOT NULL
);

-- Tabla para almacenar información de Productos
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
    Activo BIT NOT NULL,
    FOREIGN KEY (IdCategoria) REFERENCES CATEGORIAS(Id),
    FOREIGN KEY (IdFabricante) REFERENCES FABRICANTES(Id),
    FOREIGN KEY (IdMedida) REFERENCES MEDIDAS(Id)
);

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
INSERT INTO PRODUCTOS (Codigo, Nombre, Descripcion, IdCategoria, IdFabricante, IdMedida, Precio, Activo)
VALUES
('PAN001', 'Pan Integral Multigrano', 'Pan de trigo integral con semillas', 5, 1, 1, 2.99, 1),
('GAL001', 'Galletas de Avena', 'Deliciosas galletas de avena caseras', 3, 2, 2, 1.99, 1),
('SAND001', 'Sándwich de Pollo', 'Sándwich de pollo con lechuga y tomate', 4, 3, 1, 4.50, 1),
('PAN002', 'Pan de Centeno', 'Pan de centeno fresco', 5, 1, 1, 2.49, 1),
('CAKE001', 'Torta de Chocolate', 'Torta de chocolate con crema y frutas', 1, 3, 3, 15.99, 1),
('ALFA001', 'Alfajores de Dulce de Leche', 'Alfajores rellenos de dulce de leche', 6, 2, 2, 2.75, 1),
('PAN003', 'Pan de Maíz', 'Pan de maíz recién horneado', 5, 1, 1, 2.29, 1),
('CAKE002', 'Torta de Frutas', 'Torta de frutas variadas con crema', 1, 3, 3, 17.50, 1),
('BOM001', 'Bombones de Chocolate', 'Bombones de chocolate surtidos', 8, 2, 2, 8.99, 1),
('SAND002', 'Sándwich Vegetariano', 'Sándwich vegetariano con aguacate', 4, 3, 1, 5.00, 1);

-- Inserción de datos en la tabla SUCURSALES
INSERT INTO SUCURSALES (Nombre, Direccion)
VALUES
('Manteca 1', '123 Calle Principal'),
('Fabrica Merlo', '456 Avenida Delicias');

-----------------------------------------------------------------------------------------------

SELECT
    P.Id,
    P.Codigo,
    P.Nombre,
    P.Descripcion,
    C.Tipo AS Categoria,
    F.Nombre AS Fabricante,
    M.Tipo AS Medida,
    P.Precio,
    P.Activo
FROM PRODUCTOS AS P
INNER JOIN CATEGORIAS AS C ON P.IdCategoria = C.Id
INNER JOIN FABRICANTES AS F ON P.IdFabricante = F.Id
INNER JOIN MEDIDAS AS M ON P.IdMedida = M.Id;
