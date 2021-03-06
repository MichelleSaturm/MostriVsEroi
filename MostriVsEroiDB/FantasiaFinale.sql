USE [master]
GO
/****** Object:  Database [FantasiaFinale]    Script Date: 03/09/2021 14:52:33 ******/
CREATE DATABASE [FantasiaFinale]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FantasiaFinale', FILENAME = N'C:\Users\princ\FantasiaFinale.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FantasiaFinale_log', FILENAME = N'C:\Users\princ\FantasiaFinale_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [FantasiaFinale] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FantasiaFinale].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FantasiaFinale] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FantasiaFinale] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FantasiaFinale] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FantasiaFinale] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FantasiaFinale] SET ARITHABORT OFF 
GO
ALTER DATABASE [FantasiaFinale] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FantasiaFinale] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FantasiaFinale] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FantasiaFinale] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FantasiaFinale] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FantasiaFinale] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FantasiaFinale] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FantasiaFinale] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FantasiaFinale] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FantasiaFinale] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FantasiaFinale] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FantasiaFinale] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FantasiaFinale] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FantasiaFinale] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FantasiaFinale] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FantasiaFinale] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FantasiaFinale] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FantasiaFinale] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FantasiaFinale] SET  MULTI_USER 
GO
ALTER DATABASE [FantasiaFinale] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FantasiaFinale] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FantasiaFinale] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FantasiaFinale] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FantasiaFinale] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FantasiaFinale] SET QUERY_STORE = OFF
GO
USE [FantasiaFinale]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [FantasiaFinale]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[isAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Eroe]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Eroe](
	[IdEroe] [int] IDENTITY(1,1) NOT NULL,
	[NomeEroe] [nvarchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdLivelloVita] [int] NOT NULL,
	[PunteggioAccumulato] [int] NOT NULL,
	[IdUtente] [int] NOT NULL,
 CONSTRAINT [PK_Eroe] PRIMARY KEY CLUSTERED 
(
	[IdEroe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Arma]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arma](
	[IdArma] [int] IDENTITY(1,1) NOT NULL,
	[NomeArma] [nvarchar](50) NOT NULL,
	[PuntiDanno] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Arma] PRIMARY KEY CLUSTERED 
(
	[IdArma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LivelloVita]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LivelloVita](
	[IdLivelloVita] [int] IDENTITY(1,1) NOT NULL,
	[Livello] [int] NOT NULL,
	[PuntiVita] [int] NOT NULL,
 CONSTRAINT [PK_LivelloVita] PRIMARY KEY CLUSTERED 
(
	[IdLivelloVita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[UtenteConEroi]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UtenteConEroi]
AS
SELECT dbo.Arma.NomeArma, dbo.Arma.PuntiDanno, dbo.Categoria.Nome AS Categoria, dbo.Eroe.PunteggioAccumulato, dbo.Eroe.NomeEroe, dbo.LivelloVita.PuntiVita, dbo.LivelloVita.Livello, dbo.Utente.Id, dbo.Utente.Username
FROM     dbo.Arma INNER JOIN
                  dbo.Categoria ON dbo.Arma.IdCategoria = dbo.Categoria.IdCategoria INNER JOIN
                  dbo.Eroe ON dbo.Arma.IdArma = dbo.Eroe.IdArma AND dbo.Categoria.IdCategoria = dbo.Eroe.IdCategoria INNER JOIN
                  dbo.LivelloVita ON dbo.Eroe.IdLivelloVita = dbo.LivelloVita.IdLivelloVita INNER JOIN
                  dbo.Utente ON dbo.Eroe.IdUtente = dbo.Utente.Id
GO
/****** Object:  View [dbo].[ArmiConCategorieEroiEMostri]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ArmiConCategorieEroiEMostri]
AS
SELECT dbo.Categoria.Nome AS Categoria, dbo.Arma.NomeArma, dbo.Arma.PuntiDanno
FROM     dbo.Arma INNER JOIN
                  dbo.Categoria ON dbo.Arma.IdCategoria = dbo.Categoria.IdCategoria
GO
/****** Object:  View [dbo].[ClassificaGlobale]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ClassificaGlobale]
AS
SELECT TOP (10) Username, NomeEroe, Categoria, Livello, PuntiVita, PunteggioAccumulato
FROM     dbo.UtenteConEroi
ORDER BY Livello DESC, PunteggioAccumulato DESC
GO
/****** Object:  Table [dbo].[Mostro]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mostro](
	[IdMostro] [int] IDENTITY(1,1) NOT NULL,
	[NomeMostro] [nvarchar](50) NOT NULL,
	[IdArma] [int] NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdLivelloVita] [int] NOT NULL,
 CONSTRAINT [PK_Mostro] PRIMARY KEY CLUSTERED 
(
	[IdMostro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MostriConCaratteristiche]    Script Date: 03/09/2021 14:52:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MostriConCaratteristiche]
AS
SELECT dbo.Mostro.NomeMostro, dbo.Categoria.Nome AS Classe, dbo.Arma.NomeArma, dbo.Arma.PuntiDanno, dbo.LivelloVita.Livello, dbo.LivelloVita.PuntiVita
FROM     dbo.Arma INNER JOIN
                  dbo.Categoria ON dbo.Arma.IdCategoria = dbo.Categoria.IdCategoria INNER JOIN
                  dbo.Mostro ON dbo.Arma.IdArma = dbo.Mostro.IdArma AND dbo.Categoria.IdCategoria = dbo.Mostro.IdCategoria INNER JOIN
                  dbo.LivelloVita ON dbo.Mostro.IdLivelloVita = dbo.LivelloVita.IdLivelloVita
GO
SET IDENTITY_INSERT [dbo].[Arma] ON 

INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (1, N'Alabarda', 15, 1)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (2, N'Ascia', 8, 1)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (3, N'Mazza', 5, 1)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (4, N'Spada', 10, 1)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (5, N'Spadone', 15, 1)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (6, N'Arco e Frecce', 8, 2)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (7, N'Bacchetta', 5, 2)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (8, N'Bastone Magico', 10, 2)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (9, N'Onda d''Urto', 15, 2)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (10, N'Pugnale', 5, 2)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (11, N'Discorso Noioso', 4, 3)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (12, N'Farneticazione', 7, 3)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (13, N'Imprecazione', 3, 3)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (14, N'Magia Nera', 3, 3)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (15, N'Arco', 7, 4)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (16, N'Clava', 5, 4)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (17, N'Spada Rotta', 3, 4)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (18, N'Mazza Chiodata', 10, 4)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (19, N'Alabarda del Drago', 30, 5)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (20, N'Divinazione', 15, 5)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (21, N'Fulmine', 10, 5)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (22, N'Fulmine Celeste', 15, 5)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (23, N'Tempesta', 8, 5)
INSERT [dbo].[Arma] ([IdArma], [NomeArma], [PuntiDanno], [IdCategoria]) VALUES (24, N'Tempesta Oscura', 15, 5)
SET IDENTITY_INSERT [dbo].[Arma] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([IdCategoria], [Nome], [Tipo]) VALUES (1, N'Guerriero', N'Eroe')
INSERT [dbo].[Categoria] ([IdCategoria], [Nome], [Tipo]) VALUES (2, N'Mago', N'Eroe')
INSERT [dbo].[Categoria] ([IdCategoria], [Nome], [Tipo]) VALUES (3, N'Cultista', N'Mostro')
INSERT [dbo].[Categoria] ([IdCategoria], [Nome], [Tipo]) VALUES (4, N'Orco', N'Mostro')
INSERT [dbo].[Categoria] ([IdCategoria], [Nome], [Tipo]) VALUES (5, N'Signore del Male', N'Mostro')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Eroe] ON 

INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (1, N'Noctis', 1, 4, 3, 30, 1)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (5, N'Gladio', 1, 5, 1, 0, 5)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (8, N'Magnus Bane', 2, 9, 3, 0, 3)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (10, N'Diluc', 1, 5, 3, 20, 1)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (1002, N'Yanfei', 2, 8, 1, 0, 1)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2002, N'Aerith', 2, 8, 2, 20, 1006)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2003, N'Raiden Baal', 1, 1, 3, 0, 6)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2004, N'Vincent Valentine', 1, 2, 1, 0, 3)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2005, N'Kokomi', 2, 9, 1, 0, 5)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2006, N'Gandalf', 2, 8, 1, 0, 2)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2007, N'Legolas', 2, 6, 1, 0, 2)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2008, N'Kaeya', 1, 4, 3, 10, 1006)
INSERT [dbo].[Eroe] ([IdEroe], [NomeEroe], [IdCategoria], [IdArma], [IdLivelloVita], [PunteggioAccumulato], [IdUtente]) VALUES (2009, N'Cor Leonis', 1, 4, 6, 10, 1006)
SET IDENTITY_INSERT [dbo].[Eroe] OFF
GO
SET IDENTITY_INSERT [dbo].[LivelloVita] ON 

INSERT [dbo].[LivelloVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (1, 1, 20)
INSERT [dbo].[LivelloVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (2, 2, 40)
INSERT [dbo].[LivelloVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (3, 3, 60)
INSERT [dbo].[LivelloVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (5, 4, 80)
INSERT [dbo].[LivelloVita] ([IdLivelloVita], [Livello], [PuntiVita]) VALUES (6, 5, 100)
SET IDENTITY_INSERT [dbo].[LivelloVita] OFF
GO
SET IDENTITY_INSERT [dbo].[Mostro] ON 

INSERT [dbo].[Mostro] ([IdMostro], [NomeMostro], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (2, N'Hilichurl', 17, 4, 1)
INSERT [dbo].[Mostro] ([IdMostro], [NomeMostro], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (3, N'Abyss Herald', 24, 5, 6)
INSERT [dbo].[Mostro] ([IdMostro], [NomeMostro], [IdArma], [IdCategoria], [IdLivelloVita]) VALUES (1002, N'Samachurl', 14, 3, 2)
SET IDENTITY_INSERT [dbo].[Mostro] OFF
GO
SET IDENTITY_INSERT [dbo].[Utente] ON 

INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (1, N'Caleb', N'banana', 1)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (2, N'Sirius', N'mela', 1)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (3, N'Magnus', N'pera', 1)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (4, N'Ophelia', N'avocado', 1)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (5, N'Domina', N'qwerty', 0)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (6, N'Michelle', N'kaeluc', 0)
INSERT [dbo].[Utente] ([Id], [Username], [Password], [isAdmin]) VALUES (1006, N'Billy', N'tavolo', 1)
SET IDENTITY_INSERT [dbo].[Utente] OFF
GO
ALTER TABLE [dbo].[Arma]  WITH CHECK ADD  CONSTRAINT [FK_Arma_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Arma] CHECK CONSTRAINT [FK_Arma_Categoria]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([IdArma])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Arma]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Categoria]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_LivelloVita] FOREIGN KEY([IdLivelloVita])
REFERENCES [dbo].[LivelloVita] ([IdLivelloVita])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_LivelloVita]
GO
ALTER TABLE [dbo].[Eroe]  WITH CHECK ADD  CONSTRAINT [FK_Eroe_Utente] FOREIGN KEY([IdUtente])
REFERENCES [dbo].[Utente] ([Id])
GO
ALTER TABLE [dbo].[Eroe] CHECK CONSTRAINT [FK_Eroe_Utente]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Arma] FOREIGN KEY([IdArma])
REFERENCES [dbo].[Arma] ([IdArma])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Arma]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_Categoria]
GO
ALTER TABLE [dbo].[Mostro]  WITH CHECK ADD  CONSTRAINT [FK_Mostro_LivelloVita] FOREIGN KEY([IdLivelloVita])
REFERENCES [dbo].[LivelloVita] ([IdLivelloVita])
GO
ALTER TABLE [dbo].[Mostro] CHECK CONSTRAINT [FK_Mostro_LivelloVita]
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
         Begin Table = "Arma"
            Begin Extent = 
               Top = 62
               Left = 57
               Bottom = 225
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categoria"
            Begin Extent = 
               Top = 74
               Left = 439
               Bottom = 215
               Right = 661
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
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiConCategorieEroiEMostri'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ArmiConCategorieEroiEMostri'
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
         Begin Table = "UtenteConEroi"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 280
               Right = 290
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
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassificaGlobale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ClassificaGlobale'
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
         Begin Table = "Arma"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 235
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categoria"
            Begin Extent = 
               Top = 7
               Left = 318
               Bottom = 218
               Right = 540
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LivelloVita"
            Begin Extent = 
               Top = 7
               Left = 588
               Bottom = 212
               Right = 810
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Mostro"
            Begin Extent = 
               Top = 7
               Left = 858
               Bottom = 219
               Right = 1080
            End
            DisplayFlags = 280
            TopColumn = 1
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
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MostriConCaratteristiche'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MostriConCaratteristiche'
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
         Begin Table = "Arma"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 270
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Categoria"
            Begin Extent = 
               Top = 7
               Left = 318
               Bottom = 148
               Right = 540
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Eroe"
            Begin Extent = 
               Top = 7
               Left = 588
               Bottom = 170
               Right = 830
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "LivelloVita"
            Begin Extent = 
               Top = 7
               Left = 878
               Bottom = 148
               Right = 1100
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Utente"
            Begin Extent = 
               Top = 7
               Left = 1148
               Bottom = 170
               Right = 1370
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
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtenteConEroi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtenteConEroi'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UtenteConEroi'
GO
USE [master]
GO
ALTER DATABASE [FantasiaFinale] SET  READ_WRITE 
GO
