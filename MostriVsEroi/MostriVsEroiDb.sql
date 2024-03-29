USE [master]
GO
/****** Object:  Database [MostriVsEroi]    Script Date: 03/09/2021 14:55:17 ******/
CREATE DATABASE [MostriVsEroi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MostriVsEroi', FILENAME = N'C:\Users\katia\MostriVsEroi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MostriVsEroi_log', FILENAME = N'C:\Users\katia\MostriVsEroi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MostriVsEroi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MostriVsEroi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ARITHABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MostriVsEroi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MostriVsEroi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MostriVsEroi] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MostriVsEroi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MostriVsEroi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MostriVsEroi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MostriVsEroi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MostriVsEroi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MostriVsEroi] SET  MULTI_USER 
GO
ALTER DATABASE [MostriVsEroi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MostriVsEroi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MostriVsEroi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MostriVsEroi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MostriVsEroi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MostriVsEroi] SET QUERY_STORE = OFF
GO
USE [MostriVsEroi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MostriVsEroi]
GO
/****** Object:  Table [dbo].[Armi]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Armi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[IdCategorie] [int] NOT NULL,
 CONSTRAINT [PK_Armi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[IdTipo] [int] NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroi]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Livello] [int] NOT NULL,
	[Punti] [int] NOT NULL,
	[IdCategorie] [int] NOT NULL,
	[IdArmi] [int] NOT NULL,
	[IdUtenti] [int] NOT NULL,
 CONSTRAINT [PK_Eroi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mostri]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](20) NOT NULL,
	[Livello] [int] NOT NULL,
	[IdArmi] [int] NOT NULL,
	[IdCategorie] [int] NOT NULL,
 CONSTRAINT [PK_Mostri] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Punti]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Punti](
	[Livello] [int] NOT NULL,
	[Punti] [int] NULL,
 CONSTRAINT [PK_Punti] PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PuntiVita]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PuntiVita](
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_PuntiVita] PRIMARY KEY CLUSTERED 
(
	[Livello] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Admin] [bit] NOT NULL,
 CONSTRAINT [PK_Utenti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VistaGlobale]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VistaGlobale]
AS
SELECT        dbo.Armi.Nome AS Expr1, dbo.Armi.PuntiDanno, dbo.Armi.IdCategorie AS Expr2, dbo.Utenti.Nickname, dbo.Utenti.Password, dbo.Utenti.Admin, dbo.Mostri.Nome AS Expr3, dbo.Mostri.Livello AS Expr4, dbo.Mostri.IdArmi AS Expr5,
                          dbo.Mostri.IdCategorie AS Expr6, dbo.PuntiVita.PuntiVita AS Expr7, dbo.Mostri.Id AS Expr8, dbo.Eroi.Id, dbo.Eroi.Nome, dbo.Eroi.Livello, dbo.Eroi.Punti, dbo.Eroi.IdCategorie, dbo.Eroi.IdArmi, dbo.Eroi.IdUtenti
FROM            dbo.Armi INNER JOIN
                         dbo.Categorie ON dbo.Armi.IdCategorie = dbo.Categorie.Id INNER JOIN
                         dbo.Eroi ON dbo.Armi.Id = dbo.Eroi.IdArmi AND dbo.Categorie.Id = dbo.Eroi.IdCategorie INNER JOIN
                         dbo.Mostri ON dbo.Armi.Id = dbo.Mostri.IdArmi AND dbo.Categorie.Id = dbo.Mostri.IdCategorie INNER JOIN
                         dbo.Punti ON dbo.Eroi.Livello = dbo.Punti.Livello INNER JOIN
                         dbo.PuntiVita ON dbo.Eroi.Livello = dbo.PuntiVita.Livello AND dbo.Mostri.Livello = dbo.PuntiVita.Livello AND dbo.Punti.Livello = dbo.PuntiVita.Livello INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtenti = dbo.Utenti.Id
GO
/****** Object:  View [dbo].[EroiUtenti]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EroiUtenti]
AS
SELECT        TOP (10) dbo.Eroi.Id, dbo.Eroi.Nome, dbo.Eroi.Livello, dbo.Eroi.Punti, dbo.Eroi.IdUtenti, dbo.Utenti.Id AS Expr1, dbo.Utenti.Nickname, dbo.Utenti.Admin, dbo.Armi.Nome AS Expr2, dbo.Categorie.Nome AS Expr3, 
                         dbo.PuntiVita.PuntiVita
FROM            dbo.Eroi INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtenti = dbo.Utenti.Id INNER JOIN
                         dbo.Armi ON dbo.Eroi.IdArmi = dbo.Armi.Id INNER JOIN
                         dbo.Categorie ON dbo.Eroi.IdCategorie = dbo.Categorie.Id AND dbo.Armi.IdCategorie = dbo.Categorie.Id INNER JOIN
                         dbo.PuntiVita ON dbo.Eroi.Livello = dbo.PuntiVita.Livello
ORDER BY dbo.Eroi.Livello DESC, dbo.Eroi.Punti DESC
GO
/****** Object:  View [dbo].[EroiUtentiId]    Script Date: 03/09/2021 14:55:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EroiUtentiId]
AS
SELECT        TOP (10) dbo.Eroi.Nome, dbo.Eroi.Livello, dbo.Eroi.Punti, dbo.Eroi.IdCategorie, dbo.Eroi.IdArmi, dbo.Eroi.IdUtenti, dbo.PuntiVita.PuntiVita, dbo.Utenti.Nickname, dbo.Utenti.Admin, dbo.Eroi.Id
FROM            dbo.Eroi INNER JOIN
                         dbo.PuntiVita ON dbo.Eroi.Livello = dbo.PuntiVita.Livello INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtenti = dbo.Utenti.Id
ORDER BY dbo.Eroi.Livello DESC, dbo.Eroi.Punti DESC
GO
SET IDENTITY_INSERT [dbo].[Armi] ON 

INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (2, N'Ascia', 8, 1)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (3, N'Mazza', 5, 1)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (4, N'Spada', 10, 1)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (5, N'Spadone', 15, 1)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (6, N'Arco e Frecce', 8, 2)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (7, N'Bacchetta', 5, 2)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (8, N'Bastone Magico', 10, 2)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (9, N'Onda d''Urto', 15, 2)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (10, N'Pugnale', 5, 2)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (11, N'Discorso Noioso', 4, 3)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (12, N'Farneticazione', 7, 3)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (13, N'Imprecazione', 5, 3)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (14, N'Magia Nera', 3, 3)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (15, N'Arco', 7, 4)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (16, N'Clava', 5, 4)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (17, N'Spada Rotta', 3, 4)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (18, N'Mazza Chiodata', 10, 4)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (19, N'Alabarda del Drago', 30, 5)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (20, N'Divinazione', 15, 5)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (21, N'Fulmine', 10, 5)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (22, N'Fulmine Celeste', 15, 5)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (23, N'Tempesta', 8, 5)
INSERT [dbo].[Armi] ([Id], [Nome], [PuntiDanno], [IdCategorie]) VALUES (24, N'Tempesta Oscura', 15, 5)
SET IDENTITY_INSERT [dbo].[Armi] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorie] ON 

INSERT [dbo].[Categorie] ([Id], [Nome], [IdTipo]) VALUES (1, N'Guerriero', 1)
INSERT [dbo].[Categorie] ([Id], [Nome], [IdTipo]) VALUES (2, N'Mago', 1)
INSERT [dbo].[Categorie] ([Id], [Nome], [IdTipo]) VALUES (3, N'Cultista', 2)
INSERT [dbo].[Categorie] ([Id], [Nome], [IdTipo]) VALUES (4, N'Orco', 2)
INSERT [dbo].[Categorie] ([Id], [Nome], [IdTipo]) VALUES (5, N'Signore del Male', 2)
SET IDENTITY_INSERT [dbo].[Categorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroi] ON 

INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (5, N'Eroe1', 1, 15, 2, 8, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (12, N'Eroe2', 2, 15, 1, 4, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (13, N'Gandalf', 3, 30, 2, 8, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (14, N'Aragorn', 3, 0, 1, 5, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (16, N'Eroe3', 4, 80, 1, 2, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (17, N'Eroe4', 1, 2, 1, 1, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (18, N'Arya Stark', 5, 105, 1, 5, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (19, N'John Snow', 3, 60, 1, 4, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (20, N'Galadriel', 3, 22, 2, 8, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (21, N'Legolas', 2, 16, 2, 6, 1)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (22, N'Gimli', 2, 22, 1, 2, 2)
INSERT [dbo].[Eroi] ([Id], [Nome], [Livello], [Punti], [IdCategorie], [IdArmi], [IdUtenti]) VALUES (23, N'Boromir', 1, 9, 1, 3, 2)
SET IDENTITY_INSERT [dbo].[Eroi] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostri] ON 

INSERT [dbo].[Mostri] ([Id], [Nome], [Livello], [IdArmi], [IdCategorie]) VALUES (1, N'Mostro1', 1, 17, 4)
INSERT [dbo].[Mostri] ([Id], [Nome], [Livello], [IdArmi], [IdCategorie]) VALUES (3, N'Mostro2', 3, 24, 5)
INSERT [dbo].[Mostri] ([Id], [Nome], [Livello], [IdArmi], [IdCategorie]) VALUES (4, N'Mostro3', 2, 13, 3)
INSERT [dbo].[Mostri] ([Id], [Nome], [Livello], [IdArmi], [IdCategorie]) VALUES (5, N'Balrog', 1, 20, 5)
INSERT [dbo].[Mostri] ([Id], [Nome], [Livello], [IdArmi], [IdCategorie]) VALUES (6, N'Sauron', 3, 19, 5)
INSERT [dbo].[Mostri] ([Id], [Nome], [Livello], [IdArmi], [IdCategorie]) VALUES (7, N'Saruman', 4, 13, 3)
SET IDENTITY_INSERT [dbo].[Mostri] OFF
GO
INSERT [dbo].[Punti] ([Livello], [Punti]) VALUES (1, 29)
INSERT [dbo].[Punti] ([Livello], [Punti]) VALUES (2, 59)
INSERT [dbo].[Punti] ([Livello], [Punti]) VALUES (3, 89)
INSERT [dbo].[Punti] ([Livello], [Punti]) VALUES (4, 119)
INSERT [dbo].[Punti] ([Livello], [Punti]) VALUES (5, 120)
GO
INSERT [dbo].[PuntiVita] ([Livello], [PuntiVita]) VALUES (1, 20)
INSERT [dbo].[PuntiVita] ([Livello], [PuntiVita]) VALUES (2, 40)
INSERT [dbo].[PuntiVita] ([Livello], [PuntiVita]) VALUES (3, 60)
INSERT [dbo].[PuntiVita] ([Livello], [PuntiVita]) VALUES (4, 80)
INSERT [dbo].[PuntiVita] ([Livello], [PuntiVita]) VALUES (5, 100)
GO
SET IDENTITY_INSERT [dbo].[Utenti] ON 

INSERT [dbo].[Utenti] ([Id], [Nickname], [Password], [Admin]) VALUES (1, N'Kate', N'123456', 1)
INSERT [dbo].[Utenti] ([Id], [Nickname], [Password], [Admin]) VALUES (2, N'Nymeria', N'123456', 1)
INSERT [dbo].[Utenti] ([Id], [Nickname], [Password], [Admin]) VALUES (3, N'MRossi', N'123456', 0)
SET IDENTITY_INSERT [dbo].[Utenti] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Utenti__CC6CD17E99DFB25C]    Script Date: 03/09/2021 14:55:17 ******/
ALTER TABLE [dbo].[Utenti] ADD  CONSTRAINT [UQ__Utenti__CC6CD17E99DFB25C] UNIQUE NONCLUSTERED 
(
	[Nickname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Armi]  WITH CHECK ADD  CONSTRAINT [FK_Armi_Categorie] FOREIGN KEY([IdCategorie])
REFERENCES [dbo].[Categorie] ([Id])
GO
ALTER TABLE [dbo].[Armi] CHECK CONSTRAINT [FK_Armi_Categorie]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Armi] FOREIGN KEY([IdArmi])
REFERENCES [dbo].[Armi] ([Id])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Armi]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Categorie] FOREIGN KEY([IdCategorie])
REFERENCES [dbo].[Categorie] ([Id])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Categorie]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Punti] FOREIGN KEY([Livello])
REFERENCES [dbo].[Punti] ([Livello])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Punti]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_PuntiVita] FOREIGN KEY([Livello])
REFERENCES [dbo].[PuntiVita] ([Livello])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_PuntiVita]
GO
ALTER TABLE [dbo].[Eroi]  WITH CHECK ADD  CONSTRAINT [FK_Eroi_Utenti] FOREIGN KEY([IdUtenti])
REFERENCES [dbo].[Utenti] ([Id])
GO
ALTER TABLE [dbo].[Eroi] CHECK CONSTRAINT [FK_Eroi_Utenti]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_Armi] FOREIGN KEY([IdArmi])
REFERENCES [dbo].[Armi] ([Id])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_Armi]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_Categorie] FOREIGN KEY([IdCategorie])
REFERENCES [dbo].[Categorie] ([Id])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_Categorie]
GO
ALTER TABLE [dbo].[Mostri]  WITH CHECK ADD  CONSTRAINT [FK_Mostri_PuntiVita] FOREIGN KEY([Livello])
REFERENCES [dbo].[PuntiVita] ([Livello])
GO
ALTER TABLE [dbo].[Mostri] CHECK CONSTRAINT [FK_Mostri_PuntiVita]
GO
ALTER TABLE [dbo].[PuntiVita]  WITH CHECK ADD  CONSTRAINT [FK_PuntiVita_Punti] FOREIGN KEY([Livello])
REFERENCES [dbo].[Punti] ([Livello])
GO
ALTER TABLE [dbo].[PuntiVita] CHECK CONSTRAINT [FK_PuntiVita_Punti]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Eroi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 219
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Utenti"
            Begin Extent = 
               Top = 6
               Left = 266
               Bottom = 218
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Armi"
            Begin Extent = 
               Top = 6
               Left = 522
               Bottom = 136
               Right = 712
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categorie"
            Begin Extent = 
               Top = 6
               Left = 750
               Bottom = 119
               Right = 940
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PuntiVita"
            Begin Extent = 
               Top = 120
               Left = 750
               Bottom = 216
               Right = 940
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiUtenti'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiUtenti'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiUtenti'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Eroi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 258
               Right = 223
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PuntiVita"
            Begin Extent = 
               Top = 6
               Left = 266
               Bottom = 131
               Right = 455
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Utenti"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 170
               Right = 686
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 960
         Table = 1170
         Output = 855
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiUtentiId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'EroiUtentiId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[11] 2[34] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Armi"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 196
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categorie"
            Begin Extent = 
               Top = 6
               Left = 266
               Bottom = 152
               Right = 452
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Eroi"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 196
               Right = 688
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Mostri"
            Begin Extent = 
               Top = 6
               Left = 722
               Bottom = 188
               Right = 912
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Punti"
            Begin Extent = 
               Top = 6
               Left = 950
               Bottom = 102
               Right = 1140
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PuntiVita"
            Begin Extent = 
               Top = 102
               Left = 950
               Bottom = 198
               Right = 1140
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Utenti"
            Begin Extent = 
               Top = 171
               Left = 244
               Bottom = 301
               Right = 434
            End
            DisplayFlags = 280
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaGlobale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2130
         Alias = 1755
         Table = 1170
         Output = 1560
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaGlobale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VistaGlobale'
GO
USE [master]
GO
ALTER DATABASE [MostriVsEroi] SET  READ_WRITE 
GO
