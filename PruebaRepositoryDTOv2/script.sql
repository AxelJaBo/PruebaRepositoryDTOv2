USE [master]
GO
/****** Object:  Database [DB_Prueba_Repository]    Script Date: 18/08/2024 02:29:58 p. m. ******/
CREATE DATABASE [DB_Prueba_Repository]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Prueba_Repository', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_Prueba_Repository.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Prueba_Repository_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DB_Prueba_Repository_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DB_Prueba_Repository] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Prueba_Repository].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Prueba_Repository] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Prueba_Repository] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Prueba_Repository] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB_Prueba_Repository] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Prueba_Repository] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Prueba_Repository] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Prueba_Repository] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Prueba_Repository] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Prueba_Repository] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Prueba_Repository] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Prueba_Repository] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Prueba_Repository] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Prueba_Repository', N'ON'
GO
ALTER DATABASE [DB_Prueba_Repository] SET QUERY_STORE = ON
GO
ALTER DATABASE [DB_Prueba_Repository] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DB_Prueba_Repository]
GO
/****** Object:  Table [dbo].[Cat_proveedores]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cat_proveedores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[RFC] [varchar](13) NULL,
 CONSTRAINT [PK_Cat_proveedores] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cat_TipoProducto]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cat_TipoProducto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_cat_TipoProducto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
	[IDProveedor] [int] NULL,
	[IDTipo] [int] NULL,
	[Cantidad] [int] NULL,
	[FechaAlta] [datetime] NULL,
	[Modelo] [varchar](20) NULL,
	[Marca] [varchar](30) NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_AddProduct]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddProduct]
	@Nombre varchar(100),
	@IDProveedor int,
	@IDTipo int,
	@Cantidad int,
	@Modelo varchar(20),
	@Marca varchar(30)
AS
BEGIN
	insert into Productos (Nombre, IDProveedor, IDTipo, Cantidad, FechaAlta, Modelo, Marca) 
	values (@Nombre, @IDProveedor, @IDTipo, @Cantidad, GETDATE(), @Modelo, @Marca)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProducts]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetProducts]

AS
BEGIN
	Select Id, Nombre, IDProveedor, IDTipo, Cantidad, FechaAlta, Modelo, Marca from Productos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductsReport]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_GetProductsReport]
AS
BEGIN
	select p.Id as IDProducto, p.Nombre as NombreProducto, p.Marca, p.Modelo, cpro.Nombre as Proveedor, ctp.Nombre as TipoProducto, p.Cantidad from Productos as p
	inner join Cat_proveedores as cpro  on p.IDProveedor=cpro.ID
	inner join cat_TipoProducto as ctp on p.IDTipo=ctp.ID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProductTypes]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetProductTypes]
AS
BEGIN
	select ID, Nombre from cat_TipoProducto
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetProviders]    Script Date: 18/08/2024 02:29:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
CREATE PROCEDURE [dbo].[SP_GetProviders]
AS
BEGIN
	select ID, Nombre from Cat_proveedores
END
GO
USE [master]
GO
ALTER DATABASE [DB_Prueba_Repository] SET  READ_WRITE 
GO
