USE [master]
GO
/****** Object:  Database [ExamenEsther]    Script Date: 20/06/2021 09:20:49 p. m. ******/
CREATE DATABASE [ExamenEsther]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExamenEsther', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ExamenEsther.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExamenEsther_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\ExamenEsther_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ExamenEsther] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExamenEsther].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExamenEsther] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExamenEsther] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExamenEsther] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExamenEsther] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExamenEsther] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExamenEsther] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExamenEsther] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExamenEsther] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExamenEsther] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExamenEsther] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExamenEsther] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExamenEsther] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExamenEsther] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExamenEsther] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExamenEsther] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExamenEsther] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExamenEsther] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExamenEsther] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExamenEsther] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExamenEsther] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExamenEsther] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExamenEsther] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExamenEsther] SET RECOVERY FULL 
GO
ALTER DATABASE [ExamenEsther] SET  MULTI_USER 
GO
ALTER DATABASE [ExamenEsther] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExamenEsther] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExamenEsther] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExamenEsther] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExamenEsther] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ExamenEsther', N'ON'
GO
ALTER DATABASE [ExamenEsther] SET QUERY_STORE = OFF
GO
USE [ExamenEsther]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/06/2021 09:21:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](max) NOT NULL,
	[Pais] [varchar](250) NOT NULL,
	[IdentificadorFiscal] [varchar](250) NOT NULL,
	[CorreoElectronico] [varchar](250) NOT NULL,
	[Mercado] [bigint] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contactos]    Script Date: 20/06/2021 09:21:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contactos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Puesto] [varchar](250) NOT NULL,
	[Correo] [varchar](250) NOT NULL,
	[IdCliente] [bigint] NOT NULL,
 CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Direcciones]    Script Date: 20/06/2021 09:21:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Direcciones](
	[Id] [bigint] NOT NULL,
	[Calle] [varchar](250) NOT NULL,
	[NumeroExterior] [varchar](50) NOT NULL,
	[NumeroInterior] [varchar](50) NULL,
	[CodigoPostal] [bigint] NOT NULL,
	[Ciudad] [varchar](250) NOT NULL,
	[IdCliente] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Direccion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mercados]    Script Date: 20/06/2021 09:21:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mercados](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Mercado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefonos]    Script Date: 20/06/2021 09:21:27 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefonos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Telefono] [varchar](50) NULL,
	[IdContacto] [bigint] NOT NULL,
 CONSTRAINT [PK_Telefonos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [RazonSocial], [Pais], [IdentificadorFiscal], [CorreoElectronico], [Mercado]) VALUES (1, N'HP', N'Mexico', N'HP990912IJH', N'ezther-sangar@hotmail.com', 2)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Mercados] ON 

INSERT [dbo].[Mercados] ([Id], [Nombre], [Activo]) VALUES (1, N'Tecnología', 1)
INSERT [dbo].[Mercados] ([Id], [Nombre], [Activo]) VALUES (2, N'Industria', 1)
INSERT [dbo].[Mercados] ([Id], [Nombre], [Activo]) VALUES (3, N'Comsumo', 1)
INSERT [dbo].[Mercados] ([Id], [Nombre], [Activo]) VALUES (4, N'Gobierno', 1)
SET IDENTITY_INSERT [dbo].[Mercados] OFF
GO
ALTER TABLE [dbo].[Mercados] ADD  CONSTRAINT [DF_Mercados_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Mercado] FOREIGN KEY([Mercado])
REFERENCES [dbo].[Mercados] ([Id])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Cliente_Mercado]
GO
ALTER TABLE [dbo].[Contactos]  WITH CHECK ADD  CONSTRAINT [FK_Contacto_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Contactos] CHECK CONSTRAINT [FK_Contacto_Cliente]
GO
ALTER TABLE [dbo].[Direcciones]  WITH CHECK ADD  CONSTRAINT [FK_Direccion_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Direcciones] CHECK CONSTRAINT [FK_Direccion_Cliente]
GO
ALTER TABLE [dbo].[Telefonos]  WITH CHECK ADD  CONSTRAINT [FK_Telefonos_Contacto] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contactos] ([Id])
GO
ALTER TABLE [dbo].[Telefonos] CHECK CONSTRAINT [FK_Telefonos_Contacto]
GO
/****** Object:  StoredProcedure [dbo].[spClienteModificar]    Script Date: 20/06/2021 09:21:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spClienteModificar]
(
	@pId BIGINT,
	@pRazonSocial VARCHAR(MAX),
	@pPais VARCHAR(250),
	@pIdentificadorFiscal VARCHAR(250),
	@pCorreoElectronico VARCHAR(250),
	@pIdMercado BIGINT
)
AS
	SET NOCOUNT ON;

		UPDATE	Clientes
		SET		RazonSocial = @pRazonSocial,
				Pais = @pPais,
				IdentificadorFiscal	= @pIdentificadorFiscal,
				CorreoElectronico = @pCorreoElectronico,
				Mercado = @pIdMercado
		WHERE	Id = @pId	  
	SET NOCOUNT OFF;
GO
/****** Object:  StoredProcedure [dbo].[spClienteResgistrar]    Script Date: 20/06/2021 09:21:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spClienteResgistrar]
(
	@pRazonSocial VARCHAR(MAX),
	@pPais VARCHAR(250),
	@pIdentificadorFiscal VARCHAR(250),
	@pCorreoElectronico VARCHAR(250),
	@pIdMercado BIGINT
)
AS
	SET NOCOUNT ON;

	INSERT INTO Clientes
	VALUES(	@pRazonSocial,
			@pPais,
			@pIdentificadorFiscal,
			@pCorreoElectronico,
			@pIdMercado
		  )
	SET NOCOUNT OFF;
GO
/****** Object:  StoredProcedure [dbo].[spClientesConsultar]    Script Date: 20/06/2021 09:21:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spClientesConsultar]
(
	@pRazonSocial VARCHAR(MAX) NULL,
	@pPais VARCHAR(250) NULL
)
AS
	SET NOCOUNT ON;

		SELECT	Clientes.[Id],
				[RazonSocial],
				[Pais],
				[IdentificadorFiscal],
				[CorreoElectronico],
				Mercados.Nombre
		FROM	Clientes
		INNER JOIN Mercados
		ON		Clientes.Mercado = Mercados.Id
		WHERE	RazonSocial LIKE '%' + @pRazonSocial + '%'
		OR		Pais LIKE '%' + @pPais + '%'

	SET NOCOUNT OFF;
GO
/****** Object:  StoredProcedure [dbo].[spContactoModificar]    Script Date: 20/06/2021 09:21:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spContactoModificar]
(
	@pId BIGINT,
	@pNombre VARCHAR(250),
	@pPuesto VARCHAR(250),
	@pCorreo VARCHAR(250),
	@pIdCliente BIGINT
)
AS
	SET NOCOUNT ON;

		UPDATE Contactos
		SET
			[Nombre] = @pNombre,
			[Puesto] = @pPuesto,
			[Correo] = @pCorreo,
			[IdCliente] = @pIdCliente
		WHERE [Id] = @pId

	SET NOCOUNT OFF;
GO
/****** Object:  StoredProcedure [dbo].[spContactoRegistrar]    Script Date: 20/06/2021 09:21:33 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spContactoRegistrar]
(
	@pNombre VARCHAR(250),
	@pPuesto VARCHAR(250),
	@pCorreo VARCHAR(250),
	@pIdCliente BIGINT
)
AS
	SET NOCOUNT ON;

		INSERT INTO Contactos
		VALUES
		(
			@pNombre,
			@pPuesto,
			@pCorreo,
			@pIdCliente
		)

	SET NOCOUNT OFF;
GO
USE [master]
GO
ALTER DATABASE [ExamenEsther] SET  READ_WRITE 
GO
