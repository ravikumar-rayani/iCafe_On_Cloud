USE [master]
GO
/****** Object:  Database [ICafe]    Script Date: 07/15/2016 19:29:38 ******/
IF EXISTS(select * from sys.databases where name='ICafe')
DROP DATABASE [ICafe]
GO
CREATE DATABASE [ICafe] ON  PRIMARY 
( NAME = N'ICafe', FILENAME = N'X:\WorkSpace\GitHub\iCafe\DatabaseSchema\ICafe.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ICafe_log', FILENAME = N'X:\WorkSpace\GitHub\iCafe\DatabaseSchema\ICafe_log.LDF' , SIZE = 768KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO
ALTER DATABASE [ICafe] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ICafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ICafe] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ICafe] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ICafe] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ICafe] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ICafe] SET ARITHABORT OFF
GO
ALTER DATABASE [ICafe] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ICafe] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ICafe] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ICafe] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ICafe] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ICafe] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ICafe] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ICafe] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ICafe] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ICafe] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ICafe] SET  DISABLE_BROKER
GO
ALTER DATABASE [ICafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ICafe] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ICafe] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ICafe] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ICafe] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ICafe] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ICafe] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ICafe] SET  READ_WRITE
GO
ALTER DATABASE [ICafe] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ICafe] SET  MULTI_USER
GO
ALTER DATABASE [ICafe] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ICafe] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ICafe', N'ON'
GO
USE [ICafe]
GO
/****** Object:  Table [dbo].[M_Permissions]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Permissions](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_M_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Menus]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Menus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[FromTime] [datetime] NULL,
	[ToTime] [datetime] NULL,
 CONSTRAINT [PK_M_Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Tags]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Tags](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Comments] [nvarchar](300) NULL,
 CONSTRAINT [PK_M_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_ItemCategories]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_ItemCategories](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[Discount] [decimal](14, 4) NULL,
 CONSTRAINT [PK_M_ItemCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_ItemTags]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_ItemTags](
	[ItemID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_D_ItemTags] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Customers]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Customers](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_M_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Devices]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Devices](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsMultipleMode] [bit] NOT NULL,
 CONSTRAINT [PK_M_Devices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Items]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Items](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Ingrediants] [nvarchar](500) NULL,
	[IsAvailable] [bit] NULL,
	[Image] [nvarchar](500) NULL,
	[Discount] [decimal](12, 4) NULL,
	[Price] [decimal](12, 4) NULL,
	[SpicyLevel] [nvarchar](50) NULL,
 CONSTRAINT [PK_M_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_ItemsConfiguration]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_ItemsConfiguration](
	[MenuId] [int] NULL,
	[ItemCategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[Discount] [decimal](14, 4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Tables]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Tables](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DeviceID] [int] NULL,
 CONSTRAINT [PK_M_Tables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Roles]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Roles](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[PermissionId] [int] NULL,
 CONSTRAINT [PK_M_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Users]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Users](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Password] [nvarchar](50) NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_M_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[M_Orders]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_Orders](
	[Id] [int] NOT NULL,
	[TotalReOrders] [int] NULL,
	[PaymentStatus] [nvarchar](10) NULL,
	[UserId] [nvarchar](10) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_M_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[D_OrdersDetails]    Script Date: 07/15/2016 19:29:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[D_OrdersDetails](
	[OrderId] [int] NULL,
	[ItemId] [int] NULL,
	[OrderQuantiry] [int] NULL,
	[OrderType] [nvarchar](50) NULL,
	[OrderPreferences] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_D_ItemsConfiguration_M_ItemCategories]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[D_ItemsConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_D_ItemsConfiguration_M_ItemCategories] FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[M_ItemCategories] ([Id])
GO
ALTER TABLE [dbo].[D_ItemsConfiguration] CHECK CONSTRAINT [FK_D_ItemsConfiguration_M_ItemCategories]
GO
/****** Object:  ForeignKey [FK_D_ItemsConfiguration_M_Items]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[D_ItemsConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_D_ItemsConfiguration_M_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[M_Items] ([Id])
GO
ALTER TABLE [dbo].[D_ItemsConfiguration] CHECK CONSTRAINT [FK_D_ItemsConfiguration_M_Items]
GO
/****** Object:  ForeignKey [FK_D_ItemsConfiguration_M_Menus]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[D_ItemsConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_D_ItemsConfiguration_M_Menus] FOREIGN KEY([MenuId])
REFERENCES [dbo].[M_Menus] ([Id])
GO
ALTER TABLE [dbo].[D_ItemsConfiguration] CHECK CONSTRAINT [FK_D_ItemsConfiguration_M_Menus]
GO
/****** Object:  ForeignKey [FK_M_Tables_M_Devices]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[M_Tables]  WITH CHECK ADD  CONSTRAINT [FK_M_Tables_M_Devices] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[M_Devices] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[M_Tables] CHECK CONSTRAINT [FK_M_Tables_M_Devices]
GO
/****** Object:  ForeignKey [FK_M_Roles_M_Permissions]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[M_Roles]  WITH CHECK ADD  CONSTRAINT [FK_M_Roles_M_Permissions] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[M_Permissions] ([Id])
GO
ALTER TABLE [dbo].[M_Roles] CHECK CONSTRAINT [FK_M_Roles_M_Permissions]
GO
/****** Object:  ForeignKey [FK_M_Users_M_Roles]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[M_Users]  WITH CHECK ADD  CONSTRAINT [FK_M_Users_M_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[M_Roles] ([Id])
GO
ALTER TABLE [dbo].[M_Users] CHECK CONSTRAINT [FK_M_Users_M_Roles]
GO
/****** Object:  ForeignKey [FK_M_Orders_M_Customers]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[M_Orders]  WITH CHECK ADD  CONSTRAINT [FK_M_Orders_M_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[M_Customers] ([Id])
GO
ALTER TABLE [dbo].[M_Orders] CHECK CONSTRAINT [FK_M_Orders_M_Customers]
GO
/****** Object:  ForeignKey [FK_M_Orders_M_Users]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[M_Orders]  WITH CHECK ADD  CONSTRAINT [FK_M_Orders_M_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[M_Users] ([Id])
GO
ALTER TABLE [dbo].[M_Orders] CHECK CONSTRAINT [FK_M_Orders_M_Users]
GO
/****** Object:  ForeignKey [FK_D_OrdersDetails_M_Orders]    Script Date: 07/15/2016 19:29:40 ******/
ALTER TABLE [dbo].[D_OrdersDetails]  WITH CHECK ADD  CONSTRAINT [FK_D_OrdersDetails_M_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[M_Orders] ([Id])
GO
ALTER TABLE [dbo].[D_OrdersDetails] CHECK CONSTRAINT [FK_D_OrdersDetails_M_Orders]
GO
