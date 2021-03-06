USE [master]
GO
/****** Object:  Database [ICafe]    Script Date: 07/15/2016 19:29:38 ******/
IF EXISTS(select * from sys.databases where name='iCafeDB')
DROP DATABASE [iCafeDB]
GO
/****** Object:  Database [iCafeDB]    Script Date: 10/15/2016 08:21:31 ******/
CREATE DATABASE [iCafeDB] ON  PRIMARY 
( NAME = N'iCafeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.DEVSQLSERVER\MSSQL\DATA\iCafeDB.mdf' , SIZE = 3328KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'iCafeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.DEVSQLSERVER\MSSQL\DATA\iCafeDB_log.LDF' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [iCafeDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [iCafeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [iCafeDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [iCafeDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [iCafeDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [iCafeDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [iCafeDB] SET ARITHABORT OFF
GO
ALTER DATABASE [iCafeDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [iCafeDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [iCafeDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [iCafeDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [iCafeDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [iCafeDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [iCafeDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [iCafeDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [iCafeDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [iCafeDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [iCafeDB] SET  ENABLE_BROKER
GO
ALTER DATABASE [iCafeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [iCafeDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [iCafeDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [iCafeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [iCafeDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [iCafeDB] SET READ_COMMITTED_SNAPSHOT ON
GO
ALTER DATABASE [iCafeDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [iCafeDB] SET  READ_WRITE
GO
ALTER DATABASE [iCafeDB] SET RECOVERY FULL
GO
ALTER DATABASE [iCafeDB] SET  MULTI_USER
GO
ALTER DATABASE [iCafeDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [iCafeDB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'iCafeDB', N'ON'
GO
USE [iCafeDB]
GO
/****** Object:  Table [dbo].[PaymentStatus]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
 CONSTRAINT [PK_dbo.PaymentStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PaymentStatus] ON
INSERT [dbo].[PaymentStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (1, N'unpaid', N'not yet done', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[PaymentStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (2, N'paid', N'payment doen', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[PaymentStatus] OFF
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderStatus] ON
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (1, N'Open', N'Just order has been created', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (2, N'Accepted', N'Accepted the order', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (3, N'Rejected', N'Rejected the order', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (4, N'InProgress', N'order is in in progress', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderStatus] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (5, N'Delivered', N'order has been delivered', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[OrderStatus] OFF
/****** Object:  Table [dbo].[SubscriptionTypes]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubscriptionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DurationInDays] [int] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.SubscriptionTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (1, N'MasterAdmin', N'Admininstrator can access any account', CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL)
INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (3, N'AccountAdmin', N'Administrator access limited to specific account', CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL)
INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (4, N'BranchAdmin', N'Administrator access  limited specific branch ', CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL)
INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (5, N'Waiter', N'Waiter', CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL)
INSERT [dbo].[Roles] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn]) VALUES (6, N'Table', N'Table', CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
/****** Object:  Table [dbo].[Features]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.Features] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.AccountTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] ON
INSERT [dbo].[AccountTypes] ([Id], [Name], [IsActive], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, N'Trail', 1, N'Trail Version', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[AccountTypes] ([Id], [Name], [IsActive], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (7, N'Trail', 1, N'Trail Version', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AccountTypes] OFF
/****** Object:  Table [dbo].[Account]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[EmailId] [nvarchar](100) NOT NULL,
	[AccoutTypeId] [int] NOT NULL,
	[IsMultiBranchesAllowed] [bit] NOT NULL,
	[MaxBranches] [int] NOT NULL,
	[EndDate] [datetime2](0) NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccoutTypeId] ON [dbo].[Account] 
(
	[AccoutTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON
INSERT [dbo].[Account] ([Id], [Name], [IsActive], [CompanyName], [EmailId], [AccoutTypeId], [IsMultiBranchesAllowed], [MaxBranches], [EndDate], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, N'iCafe', 1, N'iCafe', N'trail@trail.com', 6, 1, 1, CAST(0x00610500FD3B0B0000 AS DateTime2), CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Account] ([Id], [Name], [IsActive], [CompanyName], [EmailId], [AccoutTypeId], [IsMultiBranchesAllowed], [MaxBranches], [EndDate], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (7, N'Trail', 1, N'KFC', N'trail@trail.com', 7, 1, 1, CAST(0x00AD1901FD3B0B0000 AS DateTime2), CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
/****** Object:  Table [dbo].[AccountTypeFeatures]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypeFeatures](
	[AccountTypeId] [int] NOT NULL,
	[FeatureId] [int] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.AccountTypeFeatures] PRIMARY KEY CLUSTERED 
(
	[AccountTypeId] ASC,
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountTypeId] ON [dbo].[AccountTypeFeatures] 
(
	[AccountTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FeatureId] ON [dbo].[AccountTypeFeatures] 
(
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeatureSubscriptionPricings]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeatureSubscriptionPricings](
	[SubscriptionTypeId] [int] NOT NULL,
	[FeatureId] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Discount] [decimal](3, 2) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.FeatureSubscriptionPricings] PRIMARY KEY CLUSTERED 
(
	[SubscriptionTypeId] ASC,
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FeatureId] ON [dbo].[FeatureSubscriptionPricings] 
(
	[FeatureId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SubscriptionTypeId] ON [dbo].[FeatureSubscriptionPricings] 
(
	[SubscriptionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Discount] [decimal](3, 2) NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[AccountId] [int] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ItemCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[ItemCategories] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ItemCategories] ON
INSERT [dbo].[ItemCategories] ([Id], [Name], [Discount], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [ImageUrl]) VALUES (6, N'Roti', NULL, N'Rotis', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL, 6, NULL)
INSERT [dbo].[ItemCategories] ([Id], [Name], [Discount], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [ImageUrl]) VALUES (7, N'Curries', NULL, N'Curries', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL, 6, NULL)
INSERT [dbo].[ItemCategories] ([Id], [Name], [Discount], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [ImageUrl]) VALUES (8, N'Roti', NULL, N'Rotis', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL, 7, NULL)
INSERT [dbo].[ItemCategories] ([Id], [Name], [Discount], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [ImageUrl]) VALUES (9, N'Curries', NULL, N'Curries', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL, 7, NULL)
INSERT [dbo].[ItemCategories] ([Id], [Name], [Discount], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [ImageUrl]) VALUES (15, N'Rice', NULL, N'Rice', CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL, 6, NULL)
SET IDENTITY_INSERT [dbo].[ItemCategories] OFF
/****** Object:  Table [dbo].[RoleFeatureAccess]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleFeatureAccess](
	[RoleID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
	[WirtePermissions] [bit] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[AccountId] [int] NOT NULL,
	[BranchId] [int] NULL,
 CONSTRAINT [PK_dbo.RolFeatureAccess] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FeatureID] ON [dbo].[RoleFeatureAccess] 
(
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleID] ON [dbo].[RoleFeatureAccess] 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccess]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccess](
	[RoleID] [int] NOT NULL,
	[FeatureID] [int] NOT NULL,
	[WirtePermissions] [bit] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[AccountId] [int] NOT NULL,
	[BranchId] [int] NULL,
 CONSTRAINT [PK_dbo.RoleAccess] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[RoleAccess] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FeatureID] ON [dbo].[RoleAccess] 
(
	[FeatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleID] ON [dbo].[RoleAccess] 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Comments] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Tags] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tags] ON
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (2, N'Veg', N'Vegetarain', CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (3, N'Non-Veg', N'Non-Vegetarain', CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (4, N'Chicken', N'Chicken', CAST(0x00000000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (5, N'Mutton', N'Mutton', CAST(0x00000000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (6, N'SeaFood', N'Sea Food', CAST(0x00000000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (7, N'Juices', N'Fruit Juices', CAST(0x00000000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Tags] ([Id], [Name], [Comments], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (8, N'Deserts', N'Ice Creams', CAST(0x009E9400F43B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[Tags] OFF
/****** Object:  Table [dbo].[Customers]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone] [decimal](12, 0) NOT NULL,
	[EmailId] [nvarchar](100) NULL,
	[Address] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[AccountId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Customers] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT [dbo].[Customers] ([Id], [Name], [Phone], [EmailId], [Address], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (1, N'Shankar', CAST(9876543210 AS Decimal(12, 0)), N'shankar@gmail.com', NULL, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
INSERT [dbo].[Customers] ([Id], [Name], [Phone], [EmailId], [Address], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId]) VALUES (4, N'Mishra', CAST(9182736450 AS Decimal(12, 0)), N'mishra@icafe.com', N'Bangalore', NULL, CAST(0x00724E01FA3B0B0000 AS DateTime2), NULL, NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[Customers] OFF
/****** Object:  Table [dbo].[Branches]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](4000) NOT NULL,
	[AccountId] [int] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.Branches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Branches] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branches] ON
INSERT [dbo].[Branches] ([Id], [Name], [AccountId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, N'HeadQuater', 6, CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Branches] ([Id], [Name], [AccountId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (7, N'Regional1', 7, CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Branches] OFF
/****** Object:  Table [dbo].[AccountSubscriptionDetails]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountSubscriptionDetails](
	[AccountId] [int] NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[SubscriptionTypeId] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.AccountSubscriptionDetails] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC,
	[AccountTypeId] ASC,
	[SubscriptionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[AccountSubscriptionDetails] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountTypeId] ON [dbo].[AccountSubscriptionDetails] 
(
	[AccountTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SubscriptionTypeId] ON [dbo].[AccountSubscriptionDetails] 
(
	[SubscriptionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[AccountId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Devices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Devices] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[Devices] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Devices] ON
INSERT [dbo].[Devices] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (1, N'Device1', N'', CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Devices] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (2, N'Device2', NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Devices] ([Id], [Name], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (3, N'Device3', NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
SET IDENTITY_INSERT [dbo].[Devices] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[AccountId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account_Branch_UserId] ON [dbo].[Users] 
(
	[UserName] ASC,
	[AccountId] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[Users] 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserName] ON [dbo].[Users] 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [UserName], [FirstName], [LastName], [Password], [RoleId], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (1, N'ravikumar', N'ravi', N'kumar', N'ravikumar', 1, CAST(0x0000A69C00A87884 AS DateTime), NULL, 6, 6)
INSERT [dbo].[Users] ([Id], [UserName], [FirstName], [LastName], [Password], [RoleId], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (2, N'KFCAdmin', N'Johnson', N'', N'johnson', 3, CAST(0x0000A69C00A87884 AS DateTime), NULL, 6, 6)
INSERT [dbo].[Users] ([Id], [UserName], [FirstName], [LastName], [Password], [RoleId], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (3, N'KFCWaiter', N'peterson', N'mc', N'peterson', 5, CAST(0x0000A69C00A87884 AS DateTime), NULL, 6, 6)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[TagsAvailablities]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsAvailablities](
	[TagId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.TagsAvailablities] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[TagsAvailablities] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TagId] ON [dbo].[TagsAvailablities] 
(
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (2, 6, 1, NULL, NULL)
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (3, 6, 1, NULL, NULL)
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (4, 6, 1, NULL, NULL)
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (5, 6, 1, NULL, NULL)
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (6, 6, 1, NULL, NULL)
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (7, 6, 1, NULL, NULL)
INSERT [dbo].[TagsAvailablities] ([TagId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (8, 6, 1, NULL, NULL)
/****** Object:  Table [dbo].[Items]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ItemCategoryId] [int] NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[SpicyLevel] [int] NOT NULL,
	[Discount] [decimal](3, 2) NULL,
	[Ingrediants] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[AccountId] [int] NOT NULL,
	[SmallImageUrl] [nvarchar](255) NULL,
	[FullImageUrl] [nvarchar](255) NULL,
 CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Items] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ItemCategoryId] ON [dbo].[Items] 
(
	[ItemCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Items] ON
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (2, N'Naan', 6, CAST(40.00 AS Decimal(10, 2)), 3, CAST(0.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (3, N'Pulka', 6, CAST(50.00 AS Decimal(10, 2)), 2, CAST(0.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (4, N'Paneer Masala', 7, CAST(210.00 AS Decimal(10, 2)), 1, CAST(1.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (5, N'Chicken Masala', 7, CAST(250.00 AS Decimal(10, 2)), 5, CAST(1.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 6, NULL, NULL)
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (6, N'Tundoori', 8, CAST(40.00 AS Decimal(10, 2)), 3, CAST(0.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 7, N'small image', N'full image')
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (7, N'Pulcha', 8, CAST(50.00 AS Decimal(10, 2)), 2, CAST(0.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 7, N'small image', N'full image')
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (8, N'Mixed Veg Curry', 9, CAST(210.00 AS Decimal(10, 2)), 1, CAST(1.00 AS Decimal(3, 2)), N'', NULL, CAST(0x00850000E03B0B0000 AS DateTime2), NULL, NULL, NULL, 7, N'small image', N'full image')
INSERT [dbo].[Items] ([Id], [Name], [ItemCategoryId], [Price], [SpicyLevel], [Discount], [Ingrediants], [Description], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy], [AccountId], [SmallImageUrl], [FullImageUrl]) VALUES (9, N'Chicken Masala', 9, CAST(250.00 AS Decimal(10, 2)), 5, CAST(1.00 AS Decimal(3, 2)), N'', NULL, CAST(0x000000000000000000 AS DateTime2), NULL, NULL, NULL, 7, N'small image', N'full image')
SET IDENTITY_INSERT [dbo].[Items] OFF
/****** Object:  Table [dbo].[ItemCategoryTags]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategoryTags](
	[ItemCategoryID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
	[AccountID] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ItemCategoryTags] ON [dbo].[ItemCategoryTags] 
(
	[ItemCategoryID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemCategoriesAvailablities]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategoriesAvailablities](
	[ItemCategoryId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.ItemCategoriesAvailablities] PRIMARY KEY CLUSTERED 
(
	[ItemCategoryId] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[ItemCategoriesAvailablities] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ItemCategoryId] ON [dbo].[ItemCategoriesAvailablities] 
(
	[ItemCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[ItemCategoriesAvailablities] ([ItemCategoryId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (6, 6, 1, NULL, NULL)
INSERT [dbo].[ItemCategoriesAvailablities] ([ItemCategoryId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (7, 6, 1, NULL, NULL)
INSERT [dbo].[ItemCategoriesAvailablities] ([ItemCategoryId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (8, 6, 1, NULL, NULL)
INSERT [dbo].[ItemCategoriesAvailablities] ([ItemCategoryId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (9, 6, 1, NULL, NULL)
INSERT [dbo].[ItemCategoriesAvailablities] ([ItemCategoryId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (15, 6, 1, NULL, NULL)
/****** Object:  Table [dbo].[Orders]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[TotalPrice] [decimal](10, 2) NOT NULL,
	[PaymentStatusId] [int] NOT NULL,
	[RatingOnFood] [int] NULL,
	[RatingOnService] [int] NULL,
	[Feedback] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[AccountId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedBy] [int] NULL,
	[BranchId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Orders] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[Orders] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_CustomerId] ON [dbo].[Orders] 
(
	[CustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_PaymentStatusId] ON [dbo].[Orders] 
(
	[PaymentStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON
INSERT [dbo].[Orders] ([Id], [CustomerId], [TotalPrice], [PaymentStatusId], [RatingOnFood], [RatingOnService], [Feedback], [CreatedOn], [ModifiedOn], [AccountId], [CreatedBy], [ModifiedBy], [BranchId]) VALUES (3, 1, CAST(3430.00 AS Decimal(10, 2)), 1, NULL, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL, 6, 3, NULL, 6)
INSERT [dbo].[Orders] ([Id], [CustomerId], [TotalPrice], [PaymentStatusId], [RatingOnFood], [RatingOnService], [Feedback], [CreatedOn], [ModifiedOn], [AccountId], [CreatedBy], [ModifiedBy], [BranchId]) VALUES (4, 1, CAST(3430.00 AS Decimal(10, 2)), 1, NULL, NULL, NULL, CAST(0x000000000000000000 AS DateTime2), NULL, 6, 0, NULL, 6)
INSERT [dbo].[Orders] ([Id], [CustomerId], [TotalPrice], [PaymentStatusId], [RatingOnFood], [RatingOnService], [Feedback], [CreatedOn], [ModifiedOn], [AccountId], [CreatedBy], [ModifiedBy], [BranchId]) VALUES (5, 1, CAST(3430.00 AS Decimal(10, 2)), 1, NULL, NULL, NULL, CAST(0x00B35001FA3B0B0000 AS DateTime2), NULL, 6, 0, NULL, 6)
INSERT [dbo].[Orders] ([Id], [CustomerId], [TotalPrice], [PaymentStatusId], [RatingOnFood], [RatingOnService], [Feedback], [CreatedOn], [ModifiedOn], [AccountId], [CreatedBy], [ModifiedBy], [BranchId]) VALUES (6, 1, CAST(3430.00 AS Decimal(10, 2)), 1, NULL, NULL, NULL, CAST(0x002E5101FA3B0B0000 AS DateTime2), NULL, 6, 0, NULL, 6)
SET IDENTITY_INSERT [dbo].[Orders] OFF
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 10/15/2016 08:21:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[SubOrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[SubOrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OrderId] ON [dbo].[OrderDetails] 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (1, 3, 4, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (2, 3, 4, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (3, 3, 4, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (4, 3, 1, CAST(0x000000000000000000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (5, 3, 1, CAST(0x000000000000000000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (6, 3, 1, CAST(0x000000000000000000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (7, 3, 1, CAST(0x000000000000000000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (8, 3, 1, CAST(0x000000000000000000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (9, 4, 1, CAST(0x000000000000000000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (10, 5, 1, CAST(0x00B55001FA3B0B0000 AS DateTime2), NULL)
INSERT [dbo].[OrderDetails] ([SubOrderId], [OrderId], [OrderStatusId], [CreatedOn], [ModifiedOn]) VALUES (11, 6, 1, CAST(0x002F5101FA3B0B0000 AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
/****** Object:  Table [dbo].[ItemTags]    Script Date: 10/15/2016 08:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemTags](
	[ItemID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
 CONSTRAINT [PK_dbo.ItemTags] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[TagID] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[ItemTags] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ItemID] ON [dbo].[ItemTags] 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TagID] ON [dbo].[ItemTags] 
(
	[TagID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (2, 2, 6, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (3, 2, 6, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (4, 2, 6, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (5, 3, 6, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (6, 2, 7, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (7, 2, 7, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (8, 2, 7, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
INSERT [dbo].[ItemTags] ([ItemID], [TagID], [AccountId], [CreatedOn], [ModifiedOn]) VALUES (9, 3, 7, CAST(0x00850000E03B0B0000 AS DateTime2), NULL)
/****** Object:  Table [dbo].[ItemsAvailablities]    Script Date: 10/15/2016 08:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsAvailablities](
	[ItemId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.ItemsAvailablities] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC,
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[ItemsAvailablities] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ItemId] ON [dbo].[ItemsAvailablities] 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (2, 6, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (3, 6, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (4, 6, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (5, 6, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (6, 7, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (7, 7, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (8, 7, 1, NULL, NULL)
INSERT [dbo].[ItemsAvailablities] ([ItemId], [BranchId], [IsAvailable], [ModifiedOn], [ModifiedBy]) VALUES (9, 7, 1, NULL, NULL)
/****** Object:  Table [dbo].[Tables]    Script Date: 10/15/2016 08:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DeviceID] [int] NOT NULL,
	[IsMultipleMode] [bit] NOT NULL,
	[Description] [nvarchar](255) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[AccountId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Tables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[Tables] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[Tables] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DeviceID] ON [dbo].[Tables] 
(
	[DeviceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tables] ON
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (1, N'Table1', 1, 0, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (2, N'Table2', 2, 0, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (3, N'Table3', 2, 0, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (4, N'Table4', 2, 0, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (5, N'Table5', 2, 0, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), CAST(0x00C38F00F73B0B0000 AS DateTime2), 6, 6)
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (7, N'Table6', 2, 0, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
INSERT [dbo].[Tables] ([Id], [Name], [DeviceID], [IsMultipleMode], [Description], [CreatedOn], [ModifiedOn], [AccountId], [BranchId]) VALUES (8, N'Table8', 3, 1, NULL, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, 6, 6)
SET IDENTITY_INSERT [dbo].[Tables] OFF
/****** Object:  Table [dbo].[WaiterTables]    Script Date: 10/15/2016 08:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WaiterTables](
	[AccountId] [int] NOT NULL,
	[BranchId] [int] NOT NULL,
	[WaiterId] [int] NOT NULL,
	[TableId] [int] NOT NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_dbo.WaiterTables] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC,
	[BranchId] ASC,
	[WaiterId] ASC,
	[TableId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_AccountId] ON [dbo].[WaiterTables] 
(
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_BranchId] ON [dbo].[WaiterTables] 
(
	[BranchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TableId] ON [dbo].[WaiterTables] 
(
	[TableId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Waiter] ON [dbo].[WaiterTables] 
(
	[WaiterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[WaiterTables] ([AccountId], [BranchId], [WaiterId], [TableId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, 6, 3, 2, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[WaiterTables] ([AccountId], [BranchId], [WaiterId], [TableId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, 6, 3, 3, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[WaiterTables] ([AccountId], [BranchId], [WaiterId], [TableId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, 6, 3, 4, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[WaiterTables] ([AccountId], [BranchId], [WaiterId], [TableId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, 6, 3, 5, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[WaiterTables] ([AccountId], [BranchId], [WaiterId], [TableId], [CreatedOn], [ModifiedOn], [CreatedBy], [ModifiedBy]) VALUES (6, 6, 3, 7, CAST(0x00C38F00F73B0B0000 AS DateTime2), NULL, NULL, NULL)
/****** Object:  Table [dbo].[SubOrderDetails]    Script Date: 10/15/2016 08:21:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubOrderDetails](
	[SubOrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[OrderQuantity] [int] NOT NULL,
	[OrderType] [nvarchar](max) NULL,
	[OrderPreferences] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](0) NOT NULL,
	[ModifiedOn] [datetime2](0) NULL,
 CONSTRAINT [PK_dbo.SubOrderDetails] PRIMARY KEY CLUSTERED 
(
	[SubOrderId] ASC,
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ItemId] ON [dbo].[SubOrderDetails] 
(
	[ItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_SubOrderId] ON [dbo].[SubOrderDetails] 
(
	[SubOrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (1, 2, 2, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (1, 3, 3, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (1, 4, 3, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (2, 5, 2, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (2, 6, 3, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (2, 7, 2, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (3, 8, 5, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (3, 9, 3, NULL, NULL, CAST(0x009E9400F43B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (4, 8, 5, NULL, NULL, CAST(0x004E3B01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (4, 9, 3, NULL, NULL, CAST(0x004E3B01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (5, 8, 5, NULL, NULL, CAST(0x006D3B01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (5, 9, 3, NULL, NULL, CAST(0x006D3B01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (6, 8, 5, NULL, NULL, CAST(0x009D3B01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (6, 9, 3, NULL, NULL, CAST(0x009D3B01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (7, 8, 5, NULL, NULL, CAST(0x000E3C01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (7, 9, 3, NULL, NULL, CAST(0x00113C01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (8, 8, 5, NULL, NULL, CAST(0x00343D01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (8, 9, 3, NULL, NULL, CAST(0x00363D01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (9, 8, 5, NULL, NULL, CAST(0x00D83D01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (9, 9, 3, NULL, NULL, CAST(0x00D83D01F93B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (10, 8, 5, NULL, NULL, CAST(0x00B55001FA3B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (10, 9, 3, NULL, NULL, CAST(0x00B55001FA3B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (11, 8, 5, NULL, NULL, CAST(0x00315101FA3B0B0000 AS DateTime2), NULL)
INSERT [dbo].[SubOrderDetails] ([SubOrderId], [ItemId], [OrderQuantity], [OrderType], [OrderPreferences], [CreatedOn], [ModifiedOn]) VALUES (11, 9, 3, NULL, NULL, CAST(0x00335101FA3B0B0000 AS DateTime2), NULL)
/****** Object:  ForeignKey [FK_dbo.Account_dbo.AccountTypes_AccoutTypeId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Account_dbo.AccountTypes_AccoutTypeId] FOREIGN KEY([AccoutTypeId])
REFERENCES [dbo].[AccountTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_dbo.Account_dbo.AccountTypes_AccoutTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.AccountTypeFeatures_dbo.AccountTypes_AccountTypeId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[AccountTypeFeatures]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountTypeFeatures_dbo.AccountTypes_AccountTypeId] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountTypeFeatures] CHECK CONSTRAINT [FK_dbo.AccountTypeFeatures_dbo.AccountTypes_AccountTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.AccountTypeFeatures_dbo.Features_FeatureId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[AccountTypeFeatures]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountTypeFeatures_dbo.Features_FeatureId] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Features] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountTypeFeatures] CHECK CONSTRAINT [FK_dbo.AccountTypeFeatures_dbo.Features_FeatureId]
GO
/****** Object:  ForeignKey [FK_dbo.FeatureSubscriptionPricings_dbo.Features_FeatureId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[FeatureSubscriptionPricings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FeatureSubscriptionPricings_dbo.Features_FeatureId] FOREIGN KEY([FeatureId])
REFERENCES [dbo].[Features] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeatureSubscriptionPricings] CHECK CONSTRAINT [FK_dbo.FeatureSubscriptionPricings_dbo.Features_FeatureId]
GO
/****** Object:  ForeignKey [FK_dbo.FeatureSubscriptionPricings_dbo.SubscriptionTypes_SubscriptionTypeId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[FeatureSubscriptionPricings]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FeatureSubscriptionPricings_dbo.SubscriptionTypes_SubscriptionTypeId] FOREIGN KEY([SubscriptionTypeId])
REFERENCES [dbo].[SubscriptionTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeatureSubscriptionPricings] CHECK CONSTRAINT [FK_dbo.FeatureSubscriptionPricings_dbo.SubscriptionTypes_SubscriptionTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.ItemCategories_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[ItemCategories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemCategories_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[ItemCategories] CHECK CONSTRAINT [FK_dbo.ItemCategories_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_Account_RoleFeatureAccess]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[RoleFeatureAccess]  WITH CHECK ADD  CONSTRAINT [FK_Account_RoleFeatureAccess] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleFeatureAccess] CHECK CONSTRAINT [FK_Account_RoleFeatureAccess]
GO
/****** Object:  ForeignKey [FK_Feature_RoleFeatureAccess]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[RoleFeatureAccess]  WITH CHECK ADD  CONSTRAINT [FK_Feature_RoleFeatureAccess] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleFeatureAccess] CHECK CONSTRAINT [FK_Feature_RoleFeatureAccess]
GO
/****** Object:  ForeignKey [FK_Role_RoleFeatureAccess]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[RoleFeatureAccess]  WITH CHECK ADD  CONSTRAINT [FK_Role_RoleFeatureAccess] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleFeatureAccess] CHECK CONSTRAINT [FK_Role_RoleFeatureAccess]
GO
/****** Object:  ForeignKey [FK_dbo.RoleAccess_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[RoleAccess]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleAccess_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccess] CHECK CONSTRAINT [FK_dbo.RoleAccess_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.RoleAccess_dbo.Features_FeatureID]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[RoleAccess]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleAccess_dbo.Features_FeatureID] FOREIGN KEY([FeatureID])
REFERENCES [dbo].[Features] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccess] CHECK CONSTRAINT [FK_dbo.RoleAccess_dbo.Features_FeatureID]
GO
/****** Object:  ForeignKey [FK_dbo.RoleAccess_dbo.Roles_RoleID]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[RoleAccess]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleAccess_dbo.Roles_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccess] CHECK CONSTRAINT [FK_dbo.RoleAccess_dbo.Roles_RoleID]
GO
/****** Object:  ForeignKey [FK_dbo.Tags_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Tags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tags_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Tags] CHECK CONSTRAINT [FK_dbo.Tags_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Customers_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Customers_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_dbo.Customers_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Branches_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Branches]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Branches_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Branches] CHECK CONSTRAINT [FK_dbo.Branches_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.AccountSubscriptionDetails_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[AccountSubscriptionDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountSubscriptionDetails_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccountSubscriptionDetails] CHECK CONSTRAINT [FK_dbo.AccountSubscriptionDetails_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.AccountSubscriptionDetails_dbo.AccountTypes_AccountTypeId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[AccountSubscriptionDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountSubscriptionDetails_dbo.AccountTypes_AccountTypeId] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountTypes] ([Id])
GO
ALTER TABLE [dbo].[AccountSubscriptionDetails] CHECK CONSTRAINT [FK_dbo.AccountSubscriptionDetails_dbo.AccountTypes_AccountTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.AccountSubscriptionDetails_dbo.SubscriptionTypes_SubscriptionTypeId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[AccountSubscriptionDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AccountSubscriptionDetails_dbo.SubscriptionTypes_SubscriptionTypeId] FOREIGN KEY([SubscriptionTypeId])
REFERENCES [dbo].[SubscriptionTypes] ([Id])
GO
ALTER TABLE [dbo].[AccountSubscriptionDetails] CHECK CONSTRAINT [FK_dbo.AccountSubscriptionDetails_dbo.SubscriptionTypes_SubscriptionTypeId]
GO
/****** Object:  ForeignKey [FK_dbo.Devices_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Devices_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_dbo.Devices_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Devices_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Devices_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_dbo.Devices_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.Users_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Users_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.Users_dbo.Roles_RoleId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_dbo.Users_dbo.Roles_RoleId]
GO
/****** Object:  ForeignKey [FK_dbo.TagsAvailablities_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[TagsAvailablities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TagsAvailablities_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagsAvailablities] CHECK CONSTRAINT [FK_dbo.TagsAvailablities_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.TagsAvailablities_dbo.Tags_TagId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[TagsAvailablities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TagsAvailablities_dbo.Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TagsAvailablities] CHECK CONSTRAINT [FK_dbo.TagsAvailablities_dbo.Tags_TagId]
GO
/****** Object:  ForeignKey [FK_dbo.Items_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Items_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_dbo.Items_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Items_dbo.ItemCategories_ItemCategoryId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Items_dbo.ItemCategories_ItemCategoryId] FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[ItemCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_dbo.Items_dbo.ItemCategories_ItemCategoryId]
GO
/****** Object:  ForeignKey [FK_ItemCategoryTags_Account]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[ItemCategoryTags]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategoryTags_Account] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemCategoryTags] CHECK CONSTRAINT [FK_ItemCategoryTags_Account]
GO
/****** Object:  ForeignKey [FK_ItemCategoryTags_ItemCategories]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[ItemCategoryTags]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategoryTags_ItemCategories] FOREIGN KEY([ItemCategoryID])
REFERENCES [dbo].[ItemCategories] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemCategoryTags] CHECK CONSTRAINT [FK_ItemCategoryTags_ItemCategories]
GO
/****** Object:  ForeignKey [FK_ItemCategoryTags_Tags]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[ItemCategoryTags]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategoryTags_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemCategoryTags] CHECK CONSTRAINT [FK_ItemCategoryTags_Tags]
GO
/****** Object:  ForeignKey [FK_dbo.ItemCategoriesAvailablities_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[ItemCategoriesAvailablities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemCategoriesAvailablities_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemCategoriesAvailablities] CHECK CONSTRAINT [FK_dbo.ItemCategoriesAvailablities_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.ItemCategoriesAvailablities_dbo.ItemCategories_ItemCategoryId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[ItemCategoriesAvailablities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemCategoriesAvailablities_dbo.ItemCategories_ItemCategoryId] FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[ItemCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemCategoriesAvailablities] CHECK CONSTRAINT [FK_dbo.ItemCategoriesAvailablities_dbo.ItemCategories_ItemCategoryId]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.Customers_CustomerId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Customers_CustomerId]
GO
/****** Object:  ForeignKey [FK_dbo.Orders_dbo.PaymentStatus_PaymentStatusId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.PaymentStatus_PaymentStatusId] FOREIGN KEY([PaymentStatusId])
REFERENCES [dbo].[PaymentStatus] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.PaymentStatus_PaymentStatusId]
GO
/****** Object:  ForeignKey [FK_dbo.OrderDetails_dbo.Orders_OrderId]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId]
GO
/****** Object:  ForeignKey [FK_OrderDetails_OrderStatus]    Script Date: 10/15/2016 08:21:34 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_OrderStatus] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[OrderStatus] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrderStatus]
GO
/****** Object:  ForeignKey [FK_dbo.ItemTags_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[ItemTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemTags_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemTags] CHECK CONSTRAINT [FK_dbo.ItemTags_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.ItemTags_dbo.Items_ItemID]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[ItemTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemTags_dbo.Items_ItemID] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[ItemTags] CHECK CONSTRAINT [FK_dbo.ItemTags_dbo.Items_ItemID]
GO
/****** Object:  ForeignKey [FK_dbo.ItemTags_dbo.Tags_TagID]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[ItemTags]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemTags_dbo.Tags_TagID] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemTags] CHECK CONSTRAINT [FK_dbo.ItemTags_dbo.Tags_TagID]
GO
/****** Object:  ForeignKey [FK_dbo.ItemsAvailablities_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[ItemsAvailablities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemsAvailablities_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemsAvailablities] CHECK CONSTRAINT [FK_dbo.ItemsAvailablities_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.ItemsAvailablities_dbo.Items_ItemId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[ItemsAvailablities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ItemsAvailablities_dbo.Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[ItemsAvailablities] CHECK CONSTRAINT [FK_dbo.ItemsAvailablities_dbo.Items_ItemId]
GO
/****** Object:  ForeignKey [FK_dbo.Tables_dbo.Account_AccountId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tables_dbo.Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_dbo.Tables_dbo.Account_AccountId]
GO
/****** Object:  ForeignKey [FK_dbo.Tables_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tables_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_dbo.Tables_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.Tables_dbo.Devices_DeviceID]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[Tables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Tables_dbo.Devices_DeviceID] FOREIGN KEY([DeviceID])
REFERENCES [dbo].[Devices] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tables] CHECK CONSTRAINT [FK_dbo.Tables_dbo.Devices_DeviceID]
GO
/****** Object:  ForeignKey [FK_dbo.WaiterTables_dbo.Account_Id]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[WaiterTables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WaiterTables_dbo.Account_Id] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WaiterTables] CHECK CONSTRAINT [FK_dbo.WaiterTables_dbo.Account_Id]
GO
/****** Object:  ForeignKey [FK_dbo.WaiterTables_dbo.Branches_BranchId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[WaiterTables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WaiterTables_dbo.Branches_BranchId] FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branches] ([Id])
GO
ALTER TABLE [dbo].[WaiterTables] CHECK CONSTRAINT [FK_dbo.WaiterTables_dbo.Branches_BranchId]
GO
/****** Object:  ForeignKey [FK_dbo.WaiterTables_dbo.Tables_TableId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[WaiterTables]  WITH CHECK ADD  CONSTRAINT [FK_dbo.WaiterTables_dbo.Tables_TableId] FOREIGN KEY([TableId])
REFERENCES [dbo].[Tables] ([Id])
GO
ALTER TABLE [dbo].[WaiterTables] CHECK CONSTRAINT [FK_dbo.WaiterTables_dbo.Tables_TableId]
GO
/****** Object:  ForeignKey [FK_WaiterTables_UserId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[WaiterTables]  WITH CHECK ADD  CONSTRAINT [FK_WaiterTables_UserId] FOREIGN KEY([WaiterId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WaiterTables] CHECK CONSTRAINT [FK_WaiterTables_UserId]
GO
/****** Object:  ForeignKey [FK_dbo.SubOrderDetails_dbo.Items_ItemId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[SubOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubOrderDetails_dbo.Items_ItemId] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubOrderDetails] CHECK CONSTRAINT [FK_dbo.SubOrderDetails_dbo.Items_ItemId]
GO
/****** Object:  ForeignKey [FK_dbo.SubOrderDetails_dbo.OrderDetails_SubOrderId]    Script Date: 10/15/2016 08:21:35 ******/
ALTER TABLE [dbo].[SubOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SubOrderDetails_dbo.OrderDetails_SubOrderId] FOREIGN KEY([SubOrderId])
REFERENCES [dbo].[OrderDetails] ([SubOrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubOrderDetails] CHECK CONSTRAINT [FK_dbo.SubOrderDetails_dbo.OrderDetails_SubOrderId]
GO
