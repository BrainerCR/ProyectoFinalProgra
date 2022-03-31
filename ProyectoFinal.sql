USE [ProyectoFinal]

/****** Object:  Table [dbo].[Cliente]    Script Date: 8/25/2021 10:46:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[CedulaCliente] [int] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[CorreoEmpleado] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED /* Custered Index: es un elemento que puede contener duplicados y nulos.*/
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[CedulaEmpleado] [int] NOT NULL,
	[NombreEmpleado] [varchar](50) NOT NULL,
	[ApellidoEmpleado] [varchar](50) NOT NULL,
	[CorreoEmpleado] [varchar](50) NOT NULL,
	[ClaveEmpleado] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[TelefonoEmpleado] [varchar](8) NOT NULL,
	[IdRol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vinculo_Producto](
	[IdVinculo_Producto] [int] IDENTITY(1,1) NOT NULL,
	[NombreVinculo_Producto] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVinculo_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroFactura](
	[IdRegistro] [int] IDENTITY(1,1) NOT NULL,
	[CodigoRegistro] [varchar](50) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[FechaFactura] [datetime] NOT NULL,
	[TotalFactura] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRegistro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[PrecioUnitario] [int] NOT NULL,
	[PrecioVenta] [int] NOT NULL,
	[IdVinculo_Producto] [int] NOT NULL,
	[IdDistribuidor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distribuidor](
	[IdDistribuidor] [int] IDENTITY(1,1) NOT NULL,
	[CedulaDistribuidor] [int] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[NombreDistribuidor] [varchar](50) NOT NULL,
	[CorreoDistribuidor] [varchar](50) NOT NULL,
	[Provincia] [varchar](50) NOT NULL,
	[TelefonoDistribuidor] [varchar](8) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDistribuidor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Empleado](
	[IdRol] [int] NOT NULL,
	[NombreRol] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol_Empleado] ([IdRol])
GO
ALTER TABLE [dbo].[RegistroFactura]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[RegistroFactura]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdVinculo_Producto])
REFERENCES [dbo].[Vinculo_Producto] ([IdVinculo_Producto])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD FOREIGN KEY([IdDistribuidor])
REFERENCES [dbo].[Distribuidor] ([IdDistribuidor])
GO
/****** Object:  StoredProcedure [dbo].[GET_SEG_USUARIO]    Script Date: 8/25/2021 10:46:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_SEG_USUARIO] @usuario VARCHAR (50),
@contrasena VARCHAR (250) 
AS BEGIN
SELECT CorreoEmpleado, ClaveEmpleado, IdRol 
FROM Empleado WHERE CorreoEmpleado = @usuario AND ClaveEmpleado = @contrasena 
END
GO