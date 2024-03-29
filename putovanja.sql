USE [master]
GO
CREATE DATABASE [Putovanja]
GO
USE [Putovanja]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/30/19 23:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odrediste]    Script Date: 06/30/19 23:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odrediste](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](max) NULL,
 CONSTRAINT [PK_Odrediste] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uposlenik]    Script Date: 06/30/19 23:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uposlenik](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](max) NULL,
	[Prezime] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Uposlenik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UposlenikOdrediste]    Script Date: 06/30/19 23:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UposlenikOdrediste](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DatumPolaska] [datetime2](7) NOT NULL,
	[DatumPovratka] [datetime2](7) NOT NULL,
	[UposlenikId] [int] NOT NULL,
	[OdredisteId] [int] NOT NULL,
	[Odobreno] [bit] NOT NULL,
	[Dokumentacija] [bit] NOT NULL,
	[Hotel] [nvarchar](max) NULL,
	[Osiguranje] [bit] NOT NULL,
	[Prevoz] [nvarchar](max) NULL,
	[Uplate] [bit] NOT NULL,
	[UposlenikPlaca] [bit] NOT NULL,
	[Odobravano] [bit] NOT NULL,
	[Zavrseno] [bit] NOT NULL,
 CONSTRAINT [PK_UposlenikOdrediste] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190611001152_inicijalno-uposlenik', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190622225629_DodanoPoljeOdobreno', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190623010916_DodanaPoljaPutovanje', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190623025516_DodanoOdobravano', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190623052347_DodanoZavrsenoPolje', N'2.1.11-servicing-32099')
SET IDENTITY_INSERT [dbo].[Odrediste] ON 

INSERT [dbo].[Odrediste] ([Id], [Naziv]) VALUES (1, N'Sarajevo')
INSERT [dbo].[Odrediste] ([Id], [Naziv]) VALUES (2, N'Mostar')
INSERT [dbo].[Odrediste] ([Id], [Naziv]) VALUES (3, N'Zagreb')
INSERT [dbo].[Odrediste] ([Id], [Naziv]) VALUES (4, N'Beograd')
SET IDENTITY_INSERT [dbo].[Odrediste] OFF
SET IDENTITY_INSERT [dbo].[Uposlenik] ON 

INSERT [dbo].[Uposlenik] ([Id], [Ime], [Prezime], [Email]) VALUES (4, N'Nejra', N'Mahmutbegovic', N'nejra.mahmutbegovic@fet.ba')
SET IDENTITY_INSERT [dbo].[Uposlenik] OFF
SET IDENTITY_INSERT [dbo].[UposlenikOdrediste] ON 

INSERT [dbo].[UposlenikOdrediste] ([Id], [DatumPolaska], [DatumPovratka], [UposlenikId], [OdredisteId], [Odobreno], [Dokumentacija], [Hotel], [Osiguranje], [Prevoz], [Uplate], [UposlenikPlaca], [Odobravano], [Zavrseno]) VALUES (10, CAST(N'2019-07-04T00:00:00.0000000' AS DateTime2), CAST(N'2019-07-09T00:00:00.0000000' AS DateTime2), 4, 2, 1, 1, N'Star Hotel, 5 ulica br: 122', 1, N'automobil', 1, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[UposlenikOdrediste] OFF
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [Odobreno]
GO
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [Dokumentacija]
GO
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [Osiguranje]
GO
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [Uplate]
GO
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [UposlenikPlaca]
GO
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [Odobravano]
GO
ALTER TABLE [dbo].[UposlenikOdrediste] ADD  DEFAULT ((0)) FOR [Zavrseno]
GO
ALTER TABLE [dbo].[UposlenikOdrediste]  WITH CHECK ADD  CONSTRAINT [FK_UposlenikOdrediste_Odrediste_OdredisteId] FOREIGN KEY([OdredisteId])
REFERENCES [dbo].[Odrediste] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UposlenikOdrediste] CHECK CONSTRAINT [FK_UposlenikOdrediste_Odrediste_OdredisteId]
GO
ALTER TABLE [dbo].[UposlenikOdrediste]  WITH CHECK ADD  CONSTRAINT [FK_UposlenikOdrediste_Uposlenik_UposlenikId] FOREIGN KEY([UposlenikId])
REFERENCES [dbo].[Uposlenik] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UposlenikOdrediste] CHECK CONSTRAINT [FK_UposlenikOdrediste_Uposlenik_UposlenikId]
GO
