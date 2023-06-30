create database DbProductos
go

use DbProductos
go

create table Categoria (
	ID_Categoria int identity,
	Descripcion varchar(45) not null,
	primary key (ID_Categoria)
);
go

create table Producto (
	ID_Producto int identity,
	Descripcion varchar(50) not null,
	Precio decimal(5,2) not null,
	ID_Categoria int,
	primary key (ID_Producto),
	constraint fk_categoria_producto foreign key (ID_Categoria) references Categoria (ID_Categoria)
);
go

-- Procedimientos almacenados de Categoría
create procedure sp_GetListaCategorias
as
begin
	select * from Categoria
end
go

create procedure sp_GetCategoriaById(
	@ID_Categoria int
)
as
begin
	select * from Categoria where ID_Categoria = @ID_Categoria
end
go

create procedure sp_InsertarCategoria(
	@Descripcion varchar(45)
)
as
begin
	insert into Categoria (Descripcion) values (@Descripcion)
end
go

create procedure sp_ActualizarCategoria(
	@ID_Categoria int,
	@Descripcion varchar(45)
)
as
begin
	update Categoria set Descripcion = @Descripcion where ID_Categoria = @ID_Categoria
end
go

create procedure sp_EliminarCategoria(
	@ID_Categoria int
)
as
begin
	delete from Categoria where ID_Categoria = @ID_Categoria
end
go

-- Datos de Categoría
exec sp_InsertarCategoria 'Bebidas'
exec sp_InsertarCategoria 'Abarrotes'
exec sp_InsertarCategoria 'Bebidas Alcohólicas'
exec sp_InsertarCategoria 'Limpieza'
go

-- Procedimientos almacenados de Producto
create procedure sp_GetListaProductos
as
begin
	select * from Producto
end
go

create procedure sp_GetProductoById(
	@ID_Producto int
)
as
begin
	select * from Producto where ID_Producto = @ID_Producto
end
go

create procedure sp_InsertarProducto(
	@Descripcion varchar(50),
	@Precio decimal (5,2),
	@ID_Categoria int
)
as
begin
	insert into Producto (Descripcion, Precio, ID_Categoria) values (@Descripcion, @Precio, @ID_Categoria)
end
go

create procedure sp_ActualizarProducto(
	@ID_Producto int,
	@Descripcion varchar(50),
	@Precio decimal (5,2),
	@ID_Categoria int
)
as
begin
	update Producto set Descripcion = @Descripcion, Precio = @Precio, ID_Categoria = @ID_Categoria
	where ID_Producto = @ID_Producto
end
go

create procedure sp_EliminarProducto(
	@ID_Producto int
)
as
begin
	delete from Producto where ID_Producto = @ID_Producto
end
go

-- Datos de Producto
exec sp_InsertarProducto 'Agua Mineral', 5.00, 1 
exec sp_InsertarProducto 'Inka Kola', 2.50, 1
exec sp_InsertarProducto 'Cerveza', 23.00, 3
exec sp_InsertarProducto 'Vino', 45, 3
exec sp_InsertarProducto 'Azúcar', 8, 2
exec sp_InsertarProducto 'Escoba', 10.00, 4
go

