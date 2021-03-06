USE [master]
GO
/****** Object:  Database [ICafe]    Script Date: 08/05/2016 11:54:04 ******/
CREATE DATABASE [ICafe] ON  PRIMARY 
( NAME = N'ICafe', FILENAME = N'X:\WorkSpace\GitHub\iCafe\DatabaseSchema\ICafe.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ICafe_log', FILENAME = N'X:\WorkSpace\GitHub\iCafe\DatabaseSchema\ICafe_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  Table [dbo].[Features]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_M_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_M_Devices] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_M_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_M_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[FromTime] [datetime] NULL,
	[ToTime] [datetime] NULL,
 CONSTRAINT [PK_M_Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Comments] [nvarchar](300) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_M_Tags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](15) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Password] [nvarchar](50) NULL,
	[RoleId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_M_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DeviceID] [int] NOT NULL,
	[IsMultipleMode] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_M_Tables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccess]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccess](
	[RoleID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
	[WirtePermissions] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsAvailable] [bit] NULL,
	[Image] [nvarchar](255) NULL,
	[Discount] [decimal](12, 4) NULL,
	[Price] [decimal](12, 4) NOT NULL,
	[SpicyLevel] [nvarchar](50) NULL,
	[Ingrediants] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastModifiedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](15) NOT NULL,
	[LastModifiedBy] [nvarchar](15) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_M_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategories](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IsAvailable] [bit] NOT NULL,
	[Discount] [decimal](10, 2) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastModifiedOn] [datetime] NULL,
	[CreatedBy] [nvarchar](15) NOT NULL,
	[LastModifiedby] [nvarchar](15) NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_M_ItemCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentStatus] [nvarchar](10) NULL,
	[UserId] [nvarchar](15) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_M_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[SubOrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[SubOrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemTags]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemTags](
	[ItemID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_ItemTags] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsConfiguration]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsConfiguration](
	[MenuId] [int] NULL,
	[ItemCategoryId] [int] NULL,
	[ItemId] [int] NULL,
	[Discount] [decimal](14, 4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubOrderDetails]    Script Date: 08/05/2016 11:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubOrderDetails](
	[SubOrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[OrderQuantiry] [int] NULL,
	[OrderType] [nvarchar](50) NULL,
	[OrderPreferences] [nvarchar](255) NULL,
 CONSTRAINT [PK_SubOrderDetails] PRIMARY KEY CLUSTERED 
(
	[SubOrderId] ASC,
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_M_Users_M_Roles]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_M_Users_M_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_M_Users_M_Roles]
GO
/****** Object:  ForeignKey [FK_Tables_Devices]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_Tables_Devices] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Devices] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_Tables_Devices]
GO
/****** Object:  ForeignKey [FK_Feature_RoleAccess]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[RoleAccess]  WITH CHECK ADD  CONSTRAINT [FK_Feature_RoleAccess] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccess] CHECK CONSTRAINT [FK_Feature_RoleAccess]
GO
/****** Object:  ForeignKey [FK_Role_RoleAccess]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[RoleAccess]  WITH CHECK ADD  CONSTRAINT [FK_Role_RoleAccess] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccess] CHECK CONSTRAINT [FK_Role_RoleAccess]
GO
/****** Object:  ForeignKey [FK_Items_User_Created]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_User_Created] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_User_Created]
GO
/****** Object:  ForeignKey [FK_ItemCategories_Users_Created]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[ItemCategories]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategories_Users_Created] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemCategories] CHECK CONSTRAINT [FK_ItemCategories_Users_Created]
GO
/****** Object:  ForeignKey [FK_Orders_Customers]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
/****** Object:  ForeignKey [FK_Orders_Users]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
/****** Object:  ForeignKey [FK_Orders_OrderDetails]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderDetails] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_Orders_OrderDetails]
GO
/****** Object:  ForeignKey [FK_Items_ItemTags]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[ItemTags]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemTags] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemTags] CHECK CONSTRAINT [FK_Items_ItemTags]
GO
/****** Object:  ForeignKey [FK_Tags_ItemTags]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[ItemTags]  WITH CHECK ADD  CONSTRAINT [FK_Tags_ItemTags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemTags] CHECK CONSTRAINT [FK_Tags_ItemTags]
GO
/****** Object:  ForeignKey [FK_D_ItemsConfiguration_M_Items]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[ItemsConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_D_ItemsConfiguration_M_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[ItemsConfiguration] CHECK CONSTRAINT [FK_D_ItemsConfiguration_M_Items]
GO
/****** Object:  ForeignKey [FK_D_ItemsConfiguration_M_Menus]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[ItemsConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_D_ItemsConfiguration_M_Menus] FOREIGN KEY([MenuId])
REFERENCES [dbo].[Menus] ([Id])
GO
ALTER TABLE [dbo].[ItemsConfiguration] CHECK CONSTRAINT [FK_D_ItemsConfiguration_M_Menus]
GO
/****** Object:  ForeignKey [FK_ItemsConfiguration_ItemCategories]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[ItemsConfiguration]  WITH CHECK ADD  CONSTRAINT [FK_ItemsConfiguration_ItemCategories] FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[ItemCategories] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemsConfiguration] CHECK CONSTRAINT [FK_ItemsConfiguration_ItemCategories]
GO
/****** Object:  ForeignKey [FK_OrderDetails_SubOrderDetails]    Script Date: 08/05/2016 11:54:05 ******/
ALTER TABLE [dbo].[SubOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_SubOrderDetails] FOREIGN KEY([SubOrderId])
REFERENCES [dbo].[OrderDetails] ([SubOrderId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubOrderDetails] CHECK CONSTRAINT [FK_OrderDetails_SubOrderDetails]
GO
