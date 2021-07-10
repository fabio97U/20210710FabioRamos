USE [master]
GO
/****** Object:  Database [easycar]    Script Date: 10/7/2021 10:14:23 ******/
CREATE DATABASE [easycar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'easycar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\easycar.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'easycar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\easycar_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [easycar] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [easycar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [easycar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [easycar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [easycar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [easycar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [easycar] SET ARITHABORT OFF 
GO
ALTER DATABASE [easycar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [easycar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [easycar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [easycar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [easycar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [easycar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [easycar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [easycar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [easycar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [easycar] SET  ENABLE_BROKER 
GO
ALTER DATABASE [easycar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [easycar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [easycar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [easycar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [easycar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [easycar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [easycar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [easycar] SET RECOVERY FULL 
GO
ALTER DATABASE [easycar] SET  MULTI_USER 
GO
ALTER DATABASE [easycar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [easycar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [easycar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [easycar] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [easycar] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'easycar', N'ON'
GO
USE [easycar]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre_completo] [varchar](100) NOT NULL,
	[dui] [varchar](15) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[telefono] [varchar](14) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[fecha_registro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[marca]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[marca](
	[id_marca] [int] IDENTITY(1,1) NOT NULL,
	[nombre_marca] [varchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[modelo]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[modelo](
	[id_modelo] [int] IDENTITY(1,1) NOT NULL,
	[nombre_modelo] [varchar](35) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_modelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[precio]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[precio](
	[id_precio] [int] IDENTITY(1,1) NOT NULL,
	[id_vehiculo] [int] NULL,
	[precio_x_hora] [float] NOT NULL,
	[precio_vehiculo] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_precio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[servicio]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicio](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NULL,
	[id_vehiculo] [int] NULL,
	[precio_total] [float] NOT NULL,
	[fecha_inicio] [datetime] NULL,
	[fecha_fin] [datetime] NULL,
	[nota] [text] NULL,
	[fecha_creacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_negocio]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_negocio](
	[id_tipo_negocio] [int] IDENTITY(1,1) NOT NULL,
	[nombre_negocio] [varchar](75) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_negocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vehiculo]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vehiculo](
	[id_vehiculo] [int] IDENTITY(1,1) NOT NULL,
	[nombre_vehiculo] [varchar](20) NULL,
	[id_marca] [int] NULL,
	[id_modelo] [int] NULL,
	[anio] [int] NOT NULL,
	[id_tipo_negocio] [int] NULL,
	[estado] [varchar](20) NOT NULL,
	[fecha_registro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_vehiculo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([id_cliente], [nombre_completo], [dui], [fecha_nacimiento], [telefono], [email], [fecha_registro]) VALUES (1, N'Fabio', N'774514', CAST(N'1910-01-27' AS Date), N'774189', N'fabio@mail.com', CAST(N'2021-07-10T09:36:18.863' AS DateTime))
SET IDENTITY_INSERT [dbo].[cliente] OFF
SET IDENTITY_INSERT [dbo].[marca] ON 

INSERT [dbo].[marca] ([id_marca], [nombre_marca]) VALUES (4, N'MITSUBISHI')
INSERT [dbo].[marca] ([id_marca], [nombre_marca]) VALUES (2, N'NISSAN')
INSERT [dbo].[marca] ([id_marca], [nombre_marca]) VALUES (1, N'Prueba2')
INSERT [dbo].[marca] ([id_marca], [nombre_marca]) VALUES (5, N'sd')
SET IDENTITY_INSERT [dbo].[marca] OFF
SET IDENTITY_INSERT [dbo].[modelo] ON 

INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (15, N'ASX')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (9, N'C-HR. Híbrido')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (10, N'Corolla Cross')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (16, N'Eclipse Cross')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (1, N'EVALIA')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (2, N'GT-R')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (17, N'i-MIEV')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (3, N'JUKE')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (18, N'L200')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (14, N'Land Cruiser 200')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (13, N'Land Cruiser Prado')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (4, N'LEAF')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (5, N'MICRA')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (19, N'Montero')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (6, N'NP300 NAVARA')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (20, N'Outlander')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (7, N'QASHQAI')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (11, N'RAV4')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (21, N'Space Star')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (12, N'SW4')
INSERT [dbo].[modelo] ([id_modelo], [nombre_modelo]) VALUES (8, N'X-TRAIL')
SET IDENTITY_INSERT [dbo].[modelo] OFF
SET IDENTITY_INSERT [dbo].[tipo_negocio] ON 

INSERT [dbo].[tipo_negocio] ([id_tipo_negocio], [nombre_negocio]) VALUES (2, N'Alquiler')
INSERT [dbo].[tipo_negocio] ([id_tipo_negocio], [nombre_negocio]) VALUES (1, N'Venta')
SET IDENTITY_INSERT [dbo].[tipo_negocio] OFF
SET IDENTITY_INSERT [dbo].[vehiculo] ON 

INSERT [dbo].[vehiculo] ([id_vehiculo], [nombre_vehiculo], [id_marca], [id_modelo], [anio], [id_tipo_negocio], [estado], [fecha_registro]) VALUES (1, N'Nissan', 4, 15, 2020, 2, N'Bueno', CAST(N'2021-07-10T10:03:58.397' AS DateTime))
SET IDENTITY_INSERT [dbo].[vehiculo] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__cliente__D876F1BF13492BE1]    Script Date: 10/7/2021 10:14:23 ******/
ALTER TABLE [dbo].[cliente] ADD UNIQUE NONCLUSTERED 
(
	[dui] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__cliente__FE74C6CC02F8EA78]    Script Date: 10/7/2021 10:14:23 ******/
ALTER TABLE [dbo].[cliente] ADD UNIQUE NONCLUSTERED 
(
	[nombre_completo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__marca__6059F5722E92FB46]    Script Date: 10/7/2021 10:14:23 ******/
ALTER TABLE [dbo].[marca] ADD UNIQUE NONCLUSTERED 
(
	[nombre_marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__modelo__0C6EF414B25F09C6]    Script Date: 10/7/2021 10:14:23 ******/
ALTER TABLE [dbo].[modelo] ADD UNIQUE NONCLUSTERED 
(
	[nombre_modelo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tipo_neg__01DE965EAC73BD1C]    Script Date: 10/7/2021 10:14:23 ******/
ALTER TABLE [dbo].[tipo_negocio] ADD UNIQUE NONCLUSTERED 
(
	[nombre_negocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cliente] ADD  DEFAULT (getdate()) FOR [fecha_registro]
GO
ALTER TABLE [dbo].[servicio] ADD  DEFAULT (getdate()) FOR [fecha_creacion]
GO
ALTER TABLE [dbo].[vehiculo] ADD  DEFAULT (getdate()) FOR [fecha_registro]
GO
ALTER TABLE [dbo].[precio]  WITH CHECK ADD FOREIGN KEY([id_vehiculo])
REFERENCES [dbo].[vehiculo] ([id_vehiculo])
GO
ALTER TABLE [dbo].[servicio]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[cliente] ([id_cliente])
GO
ALTER TABLE [dbo].[servicio]  WITH CHECK ADD FOREIGN KEY([id_vehiculo])
REFERENCES [dbo].[vehiculo] ([id_vehiculo])
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD FOREIGN KEY([id_marca])
REFERENCES [dbo].[marca] ([id_marca])
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD FOREIGN KEY([id_modelo])
REFERENCES [dbo].[modelo] ([id_modelo])
GO
ALTER TABLE [dbo].[vehiculo]  WITH CHECK ADD FOREIGN KEY([id_tipo_negocio])
REFERENCES [dbo].[tipo_negocio] ([id_tipo_negocio])
GO
/****** Object:  StoredProcedure [dbo].[sp_cliente]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Fabio Ramos>
-- Create date: <10/07/2021>
-- Description:	<Mantenimiento para cliente>
-- =============================================
CREATE PROCEDURE [dbo].[sp_cliente]
	@opcion int = 0,
	@id_cliente int = 0,
	@nombre_completo varchar(100) = '',
	@dui varchar(15) = '',
	@fecha_nacimiento date = null,
	@telefono varchar(14) = '',
	@email varchar(150) = ''

AS
BEGIN
	if(@opcion = 1)--Registro de cliente
	begin
		if exists(select 1 from cliente where dui = @dui)
		begin
			print 'Dui ya existe'
			select -1
		end
		else if exists(select 1 from cliente where email = @email)
		begin
			print 'Email ya existe'
			select -2
		end
		else
		begin
			insert into cliente(nombre_completo,dui,fecha_nacimiento,telefono,email)
			values(@nombre_completo,@dui,@fecha_nacimiento,@telefono,@email)
			select SCOPE_IDENTITY()
		end
	end
	if(@opcion = 2)--Actualizar cliente
	begin
		if exists(select 1 from cliente where email = @email and id_cliente <> @id_cliente)
		begin
			print 'Email ya existe'
			select -1
		end
		else
		begin
			update cliente set nombre_completo = @nombre_completo, telefono = @telefono,
			email = @email where id_cliente = @id_cliente
			select @id_cliente
		end
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_marca]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Fabio Ramos>
-- Create date: <10/07/2021>
-- Description:	<Mantenimiento para marca>
-- =============================================
CREATE PROCEDURE [dbo].[sp_marca]
	@opcion int = 0,
	@id_marca int = 0,
	@nombre_marca varchar(35) = ''
AS
BEGIN
	if(@opcion = 1)--Registro de marca
	begin
		if exists(select 1 from marca where nombre_marca = @nombre_marca)
		begin
			print 'Ya existe esta marca'
			select -1
		end
		else
		begin
			insert into marca(nombre_marca)values(@nombre_marca)
			select SCOPE_IDENTITY()
		end
	end
	---
	if(@opcion = 2)--Actualizar marca
	begin
		if exists(select 1 from marca where nombre_marca = @nombre_marca and id_marca <> @id_marca)
		begin
			print 'Ya existe esta marca'
			select -1
		end
		else
		begin
			update marca set nombre_marca = @nombre_marca where id_marca = @id_marca
			select @id_marca
		end
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_modelo]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Fabio Ramos>
-- Create date: <10/07/2021>
-- Description:	<Mantenimiento para modelo>
-- =============================================
CREATE PROCEDURE [dbo].[sp_modelo]
	@opcion int = 0,
	@id_modelo int = 0,
	@nombre_modelo varchar(35) = ''
AS
BEGIN
	if(@opcion = 1)--Registro de modelo
	begin
		if exists(select 1 from modelo where nombre_modelo = @nombre_modelo)
		begin
			print 'Ya existe este modelo'
			select -1
		end
		else
		begin
			insert into modelo(nombre_modelo)values(@nombre_modelo)
			select SCOPE_IDENTITY()
		end
	end
	---
	if(@opcion = 2)--Actualizar modelo
	begin
		if exists(select 1 from modelo where nombre_modelo = @nombre_modelo and id_modelo <> @id_modelo)
		begin
			print 'Ya existe este modelo'
			select -1
		end
		else
		begin
			update modelo set nombre_modelo = @nombre_modelo where id_modelo = @id_modelo
			select @id_modelo
		end
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_precio]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Fabio Ramos>
-- Create date: <10/07/2021>
-- Description:	<Mantenimiento para precio>
-- =============================================
CREATE PROCEDURE [dbo].[sp_precio]
	@opcion int = 0,
	@id_precio int = 0,
	@id_vehiculo int = 0,
	@precio_x_hora float = 0,
	@precio_vehiculo float = 0
AS
BEGIN
	if(@opcion = 1)--Registro de precio
	begin
		if exists(select 1 from precio where id_vehiculo = @id_vehiculo)
		begin
			print 'Ya existe precio para el vehiculo'
			select -1
		end
		else
		begin
			insert into precio(id_vehiculo, precio_x_hora, precio_vehiculo)values(@id_vehiculo, @precio_x_hora, @precio_vehiculo)
			select SCOPE_IDENTITY()
		end
	end
	---
	if(@opcion = 2)--Actualizar precio
	begin
		update precio set precio_x_hora = @precio_x_hora, precio_vehiculo = @precio_vehiculo where id_precio = @id_precio
		select @id_precio
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tipo_negocio]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Fabio Ramos>
-- Create date: <10/07/2021>
-- Description:	<Mantenimiento para tipo_negocio>
-- =============================================
CREATE PROCEDURE [dbo].[sp_tipo_negocio]
	@opcion int = 0,
	@id_tipo_negocio int = 0,
	@nombre_tipo_negocio varchar(35) = ''
AS
BEGIN
	if(@opcion = 1)--Registro de tipo_negocio
	begin
		if exists(select 1 from tipo_negocio where nombre_negocio = @nombre_tipo_negocio)
		begin
			print 'Ya existe este tipo de negocio'
			select -1
		end
		else
		begin
			insert into tipo_negocio(nombre_negocio)values(@nombre_tipo_negocio)
			select SCOPE_IDENTITY()
		end
	end
	---
	if(@opcion = 2)--Actualizar tipo_negocio
	begin
		if exists(select 1 from tipo_negocio where nombre_negocio = @nombre_tipo_negocio and id_tipo_negocio <> @id_tipo_negocio)
		begin
			print 'Ya existe este tipo de negocio'
			select -1
		end
		else
		begin
			update tipo_negocio set nombre_negocio = @nombre_tipo_negocio where id_tipo_negocio = @id_tipo_negocio
			select @id_tipo_negocio
		end
	end
END
GO
/****** Object:  StoredProcedure [dbo].[sp_vehiculo]    Script Date: 10/7/2021 10:14:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Fabio Ramos>
-- Create date: <10/07/2021>
-- Description:	<Mantenimiento para vehiculo>
-- =============================================
CREATE PROCEDURE [dbo].[sp_vehiculo]
	@opcion int = 0,
	@id_vehiculo int = 0,
	@nombre_vehiculo varchar(35) = '',
	@id_marca int = 0,
	@id_modelo int = 0,
	@anio int = 0,
	@id_tipo_negocio int = 0,
	@estado varchar(20) = ''
AS
BEGIN
	if(@opcion = 1)--Registro de vehiculo
	begin
		insert into vehiculo(nombre_vehiculo, id_marca, id_modelo, anio, id_tipo_negocio, estado)
					values(@nombre_vehiculo, @id_marca, @id_modelo, @anio, @id_tipo_negocio, @estado)
			select SCOPE_IDENTITY()
	end
	---
	if(@opcion = 2)--Actualizar vehiculo
	begin
		update vehiculo set nombre_vehiculo = @nombre_vehiculo, id_marca = @id_marca, id_modelo = @id_modelo,
				anio = @anio, id_tipo_negocio = @id_tipo_negocio
		where id_vehiculo = @id_vehiculo
			select @id_vehiculo
	end
END
GO
USE [master]
GO
ALTER DATABASE [easycar] SET  READ_WRITE 
GO
