use master
go
create database easycar
go

use easycar
GO

create table cliente
(
    id_cliente int primary key identity(1,1),
    nombre_completo varchar(100) not null unique,
    dui varchar(15) not null unique,
    fecha_nacimiento date not null,
    telefono varchar(14) not null,
    email varchar(150) not null,
    fecha_registro datetime default getdate()
);
go
create table marca
(
    id_marca int primary key identity(1,1),
    nombre_marca varchar(35) not null unique
);
go
create table modelo
(
    id_modelo int primary key identity(1,1),
    nombre_modelo varchar(35) not null unique
);
go
create table tipo_negocio
(
	id_tipo_negocio int primary key identity(1,1),
	nombre_negocio varchar(75) not null unique
);
go
create table vehiculo
(
    id_vehiculo int primary key identity(1,1),
    nombre_vehiculo varchar(20),
    id_marca int references marca(id_marca),
    id_modelo int references modelo(id_modelo),
    anio int not null,   
    id_tipo_negocio int references tipo_negocio(id_tipo_negocio),
    estado varchar(20) not null,
    fecha_registro datetime default getdate()
);
go
create table precio
(
    id_precio int primary key identity(1,1),
    id_vehiculo int references vehiculo(id_vehiculo),
    precio_x_hora float not null,
    precio_vehiculo float not null
);
create table servicio
(
    id_servicio int primary key identity(1,1),
    id_cliente int references cliente(id_cliente),
    id_vehiculo int references vehiculo(id_vehiculo),
    precio_total float not null,
    fecha_inicio datetime null,
    fecha_fin datetime null,
    nota text null,
    fecha_creacion datetime default getdate()
);
