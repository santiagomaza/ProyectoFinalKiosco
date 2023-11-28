--SE CREA LA BASE DE DATO (KIOSCO0) Y SE LA USA
create database Kiosco0;
use Kiosco0;

--CREAMOS LA TABLA CLIENTE 
create table Cliente
(
   Id_Cliente int identity (1,1) primary key,
   NombreYAp_Cliente varchar(40) not null,
   Edad int not null
);

drop table Cliente

--CREAMOS LA TABLA PRODUCTO
create table Producto
(
   Id_Producto int identity (1,1) primary key,
   Nombre_Producto varchar(40),
   Precio_Producto decimal (10,2),
   Cantidad_Producto int
);

drop table Producto

--CREAMOS LA TABLA RELACIONADA VENTA CON SUS RELACIONES CORRESPONDIENTE 
create table Venta
(
   Id_Venta int identity(1,1) primary key,
   Fecha_Venta varchar(15),
   Id_Producto int foreign key references Producto (Id_Producto),
   Id_Cliente int foreign key references Cliente (Id_Cliente),
);

drop table Venta

--CREAMOS LA TABLA PROVEEDOR
create table Proveedor
(
	Id_Proveedor int identity(1,1) primary key,
	Nombre_Proveedor varchar(40),
	Apellio_Proveedor varchar(30),
	Nombre_Empresa varchar(40)
);

--CREAMOS LA TABLA EMPLEADO
create table Empleado
(
   Id_Empleado int identity (1,1) primary key,
   Nombre_Empleado varchar(40),
   Apellido_Empleado varchar(40),
   Salario_Empleado decimal (10,2) 
);

--SE INSERTAN LOS REGISTROS EN LA TABLA CLIENTE
insert into Cliente values
('Jose Maria Suarez Coronel',23),
('Micaela Del milagro Diaz', 45),
('Dionisio Nuñez', 75),
('Lionel Messi', 36),
('Diego Armando Maradona', 53),
('Robert Lewandowski', 34),
('Kylian Mbappe', 24)

--SE INSERTAN LOS REGISTROS EN LA TABLA PRODUCTOS
insert into Producto values
('Yerba amanda de 1kg',1050.22,12),
('Fernet vittone',3400.11,15),
('Vino blanco estancia tucumana ',1400.30,29),
('Fideos moñito', 850.30, 7),
('Chocolate Aguila', 600, 30),
('Agua KIN', 300.50, 40),
('Encendedor BIC', 200, 25)

--SE INSERTAN LOS REGISTROS EN LA TABLA VENTA
insert into Venta values ('2023/10/10',2,1),
('2022/11/11', 3,2),
('2020/05/15', 4,3),
('2022/01/05', 5,4),
('2021/03/22', 6,3)

--SE INSERTAN LOS REGISTROS EN LA TABLA EMPLEADO
insert into Empleado values ('Joselino','Diaz',400500),
('Marisa','Argañaraz',4033330),('Santino','Segovia',4002220);

--SE INSERTAN LOS REGISTROS EN LA TABLA PROVEEDOR 
insert into Proveedor values ('Emilia','Viernes','Quilmes S.A'),
('Martina','Gomez','Coca Cola S.A'),('Domingo','Sandez','Arcor S.A');

--SE MUESTRAN TODOS LOS REGISTROS DE LAS TABLAS SELECCIONADAS
select * from Venta;
select * from Proveedor;
select * from Empleado;

--Procedimiento para mostrar los clientes (en C# se mostrarán en un combo box)
create procedure mostrarCliente
as
begin
select Id_Cliente, NombreyAp_Cliente from Cliente;
end

--SE EJECUTA EL PROCEDIMIENTO ALMACENADO 
exec mostrarCliente

drop proc mostrarCliente

--SE CREA EL PROCEDIMIENTO ALMACENADO
create procedure ListarVentas
as
begin
select ve.Id_Venta, ve.Fecha_Venta 'Fecha de Venta', cl.NombreYAp_Cliente 'Nombre del Cliente', pr.Nombre_Producto 'Nombre del Producto'
from Venta ve
join Producto pr on ve.Id_Producto = pr.Id_Producto --CON EL JOIN MOSTRAMOS LA RELACION EN LA TABLA DE VENTAS EL IDPRODUCTO Y IDCLIENTE 
join Cliente cl on ve.Id_Cliente = cl.Id_Cliente
end

--SE EJECUTA EL PROCEDIMIENTO ALMACENADO
exec ListarVentas

drop procedure ListarVentas
--DELETE ELIMINA DE LA TABLA VENTA CUANDO SE CUMPLA LA CONDICION POR MEDIO DE UNA ID 
delete from Venta where Id_Venta = 19;

--COMANDO PARA ACTUALIZAR DATOS DONDE SE CUMPLA LA CONDICION 
update Venta set Fecha_Venta = '2018/05/23', Id_Producto = 2, Id_Cliente = 1 where Id_Venta = 3

--PROCEDIMIENTO ALMACENADO PARA INSERTAR NUEVOS PRODUCTOS CON PARAMETROS
create procedure insertarProducto
@Nombre_Producto varchar(50),
@Precio_Producto decimal,
@Cantidad_Producto int
as
begin
insert into Producto values (@Nombre_Producto, @Precio_Producto, @Cantidad_Producto)
end

--EJECUTA EL PROCEDIMIENTO ALMACENADO
exec insertarProducto 'Mortadela Paladini', 450.50, 2

select * from Producto

drop procedure insertarProducto

-- PROCEDIMIENTO ALMACENADO PARA INSERTAR CLIENTES POR PARAMETROS
create proc insertarCliente
@NombreyAp_Cliente varchar(40),
@Edad int
as
begin
insert into Cliente values (@NombreYAp_Cliente, @Edad)
end

--EJECUTAMOS EL PROCEDIMIENTO ALMACENADO 
exec insertarCliente 'Walter Nuñez', 33
exec insertarCliente 'Santiago Maza', 24
exec insertarCliente 'Ramiro Argañaraz', 21
exec insertarCliente 'Nicolas Alvarez', 22

select * from cliente

--create procedure insertarVenta
--@Fecha_Venta date,
--@Id_Pedido int,
--@Id_Cliente int
--as
--begin
--insert into Venta values (@Fecha_Venta, @Id_Pedido, @Id_Cliente)
--end

--drop procedure insertarVenta

--exec insertarVenta
