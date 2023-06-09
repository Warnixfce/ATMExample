USE [master]
GO

/****** Object:  Database [ATM]    Script Date: 4/21/2023 7:21:59 PM ******/
CREATE DATABASE [ATM]

ALTER DATABASE [ATM] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ATM] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ATM] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ATM] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ATM] SET ARITHABORT OFF 
GO

ALTER DATABASE [ATM] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ATM] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ATM] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ATM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ATM] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ATM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ATM] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ATM] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ATM] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ATM] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ATM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ATM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ATM] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ATM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ATM] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ATM] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ATM] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ATM] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ATM] SET  MULTI_USER 
GO

ALTER DATABASE [ATM] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ATM] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ATM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ATM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ATM] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ATM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ATM] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ATM] SET  READ_WRITE 
GO


USE [ATM]
GO
/****** Object:  Table [dbo].[Estado_Tarjeta]    Script Date: 4/21/2023 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado_Tarjeta](
	[ID_Estado] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Estado_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[ID_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion_Administrativa]    Script Date: 4/21/2023 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion_Administrativa](
	[ID_Operacion_Administrativa] [int] IDENTITY(1,1) NOT NULL,
	[ID_Tarjeta] [int] NOT NULL,
	[ID_Tipo_Operacion] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
 CONSTRAINT [PK_Operacion_Administrativa] PRIMARY KEY CLUSTERED 
(
	[ID_Operacion_Administrativa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion_Monetaria]    Script Date: 4/21/2023 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion_Monetaria](
	[ID_Operacion_Monetaria] [int] IDENTITY(1,1) NOT NULL,
	[ID_Tarjeta] [int] NOT NULL,
	[ID_Tipo_Operacion] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Monto] [decimal](20, 2) NOT NULL,
 CONSTRAINT [PK_Operacion_Monetaria] PRIMARY KEY CLUSTERED 
(
	[ID_Operacion_Monetaria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 4/21/2023 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[ID_Tarjeta] [int] NOT NULL,
	[Numero_Tarjeta] [bigint] NOT NULL,
	[PIN] [int] NOT NULL,
	[Fecha_Vencimiento] [varchar](5) NOT NULL,
	[Balance] [decimal](20, 2) NOT NULL,
	[ID_Estado] [int] NOT NULL,
	[Intentos] [smallint] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[ID_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Operacion]    Script Date: 4/21/2023 7:21:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Operacion](
	[ID_Tipo_Operacion] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Operacion] PRIMARY KEY CLUSTERED 
(
	[ID_Tipo_Operacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Estado_Tarjeta] ([ID_Estado], [Nombre], [Descripcion]) VALUES (1, N'Activa', N'Se encuentra activa para operar con normalidad')
INSERT [dbo].[Estado_Tarjeta] ([ID_Estado], [Nombre], [Descripcion]) VALUES (2, N'Bloqueada', N'No se encuentra disponible para operar potencialme')
INSERT [dbo].[Estado_Tarjeta] ([ID_Estado], [Nombre], [Descripcion]) VALUES (3, N'Inactiva', N'No se encuentra activada para operar')
GO
SET IDENTITY_INSERT [dbo].[Operacion_Administrativa] ON 

INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (1, 1, 1, CAST(N'2023-04-21T16:25:58.690' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (2, 1, 1, CAST(N'2023-04-11T18:45:18.970' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (3, 1, 1, CAST(N'2023-04-21T17:11:26.170' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (4, 1, 1, CAST(N'2023-04-21T17:11:51.043' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (5, 1, 1, CAST(N'2023-04-21T17:13:23.287' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (6, 1, 1, CAST(N'2023-04-21T17:14:08.593' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (7, 1, 1, CAST(N'2023-04-21T18:15:00.273' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (8, 1, 1, CAST(N'2023-04-21T19:15:19.380' AS DateTime))
INSERT [dbo].[Operacion_Administrativa] ([ID_Operacion_Administrativa], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora]) VALUES (9, 1, 1, CAST(N'2023-04-21T19:17:43.037' AS DateTime))
SET IDENTITY_INSERT [dbo].[Operacion_Administrativa] OFF
GO
SET IDENTITY_INSERT [dbo].[Operacion_Monetaria] ON 

INSERT [dbo].[Operacion_Monetaria] ([ID_Operacion_Monetaria], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora], [Monto]) VALUES (1, 1, 2, CAST(N'2023-04-09T18:45:18.970' AS DateTime), CAST(200.00 AS Decimal(20, 2)))
INSERT [dbo].[Operacion_Monetaria] ([ID_Operacion_Monetaria], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora], [Monto]) VALUES (2, 1, 2, CAST(N'2023-04-10T18:45:18.970' AS DateTime), CAST(300.00 AS Decimal(20, 2)))
INSERT [dbo].[Operacion_Monetaria] ([ID_Operacion_Monetaria], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora], [Monto]) VALUES (3, 1, 2, CAST(N'2023-04-21T17:12:45.730' AS DateTime), CAST(1000.00 AS Decimal(20, 2)))
INSERT [dbo].[Operacion_Monetaria] ([ID_Operacion_Monetaria], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora], [Monto]) VALUES (4, 1, 2, CAST(N'2023-04-21T18:14:51.947' AS DateTime), CAST(500.00 AS Decimal(20, 2)))
INSERT [dbo].[Operacion_Monetaria] ([ID_Operacion_Monetaria], [ID_Tarjeta], [ID_Tipo_Operacion], [FechaHora], [Monto]) VALUES (5, 1, 2, CAST(N'2023-04-21T19:15:29.517' AS DateTime), CAST(20.00 AS Decimal(20, 2)))
SET IDENTITY_INSERT [dbo].[Operacion_Monetaria] OFF
GO
INSERT [dbo].[Tarjeta] ([ID_Tarjeta], [Numero_Tarjeta], [PIN], [Fecha_Vencimiento], [Balance], [ID_Estado], [Intentos]) VALUES (1, 5405730001030255, 1739, N'05/30', CAST(5480.00 AS Decimal(20, 2)), 1, 2)
INSERT [dbo].[Tarjeta] ([ID_Tarjeta], [Numero_Tarjeta], [PIN], [Fecha_Vencimiento], [Balance], [ID_Estado], [Intentos]) VALUES (2, 1234456478971231, 7471, N'08/28', CAST(20000.00 AS Decimal(20, 2)), 2, 0)
GO
INSERT [dbo].[Tipo_Operacion] ([ID_Tipo_Operacion], [Nombre], [Descripcion]) VALUES (1, N'Consulta', N'Consulta de balance')
INSERT [dbo].[Tipo_Operacion] ([ID_Tipo_Operacion], [Nombre], [Descripcion]) VALUES (2, N'Retiro', N'Retiro de fondos')
INSERT [dbo].[Tipo_Operacion] ([ID_Tipo_Operacion], [Nombre], [Descripcion]) VALUES (3, N'Ingreso', N'Ingreso de fondos')
GO
ALTER TABLE [dbo].[Tarjeta] ADD  CONSTRAINT [DF_Tarjeta_Balance]  DEFAULT ((0)) FOR [Balance]
GO
ALTER TABLE [dbo].[Operacion_Administrativa]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Administrativa_Tarjeta] FOREIGN KEY([ID_Tarjeta])
REFERENCES [dbo].[Tarjeta] ([ID_Tarjeta])
GO
ALTER TABLE [dbo].[Operacion_Administrativa] CHECK CONSTRAINT [FK_Operacion_Administrativa_Tarjeta]
GO
ALTER TABLE [dbo].[Operacion_Administrativa]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Administrativa_Tipo_Operacion] FOREIGN KEY([ID_Tipo_Operacion])
REFERENCES [dbo].[Tipo_Operacion] ([ID_Tipo_Operacion])
GO
ALTER TABLE [dbo].[Operacion_Administrativa] CHECK CONSTRAINT [FK_Operacion_Administrativa_Tipo_Operacion]
GO
ALTER TABLE [dbo].[Operacion_Monetaria]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Monetaria_Tarjeta] FOREIGN KEY([ID_Tarjeta])
REFERENCES [dbo].[Tarjeta] ([ID_Tarjeta])
GO
ALTER TABLE [dbo].[Operacion_Monetaria] CHECK CONSTRAINT [FK_Operacion_Monetaria_Tarjeta]
GO
ALTER TABLE [dbo].[Operacion_Monetaria]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Monetaria_Tipo_Operacion] FOREIGN KEY([ID_Tipo_Operacion])
REFERENCES [dbo].[Tipo_Operacion] ([ID_Tipo_Operacion])
GO
ALTER TABLE [dbo].[Operacion_Monetaria] CHECK CONSTRAINT [FK_Operacion_Monetaria_Tipo_Operacion]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Estado_Tarjeta] FOREIGN KEY([ID_Estado])
REFERENCES [dbo].[Estado_Tarjeta] ([ID_Estado])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Estado_Tarjeta]
GO
