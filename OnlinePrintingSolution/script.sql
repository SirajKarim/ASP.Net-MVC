USE [OPS]
GO
/****** Object:  Table [dbo].[CustomerData]    Script Date: 10/31/2018 12:43:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerData](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[CompanyName] [nvarchar](50) NOT NULL,
	[ContactNo] [int] NOT NULL,
	[ContactTitle] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Nic] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerData] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DBoyDetail]    Script Date: 10/31/2018 12:43:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DBoyDetail](
	[DBoyID] [int] IDENTITY(1,1) NOT NULL,
	[DBoyName] [nvarchar](50) NOT NULL,
	[DContactNo] [int] NOT NULL,
	[DContactTitle] [nvarchar](1) NOT NULL,
	[DBAddress] [nvarchar](50) NOT NULL,
	[DBCity] [nvarchar](50) NULL,
	[DBNic] [decimal](18, 0) NOT NULL,
	[DBEmail] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DBoyId] PRIMARY KEY CLUSTERED 
(
	[DBoyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 10/31/2018 12:43:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[OrderID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[DEmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[DEmployeeName] [nvarchar](50) NOT NULL,
	[ShipCity] [nvarchar](50) NOT NULL,
	[Shipcountry] [nvarchar](50) NOT NULL,
	[ShipAddress] [nvarchar](50) NOT NULL,
	[OrderDate] [int] NOT NULL,
	[RequiredDate] [int] NOT NULL,
	[ShipedDate] [int] NOT NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[DEmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrinterReg]    Script Date: 10/31/2018 12:43:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrinterReg](
	[PrinterID] [int] IDENTITY(1,1) NOT NULL,
	[PCompanyName] [nvarchar](50) NULL,
	[OwnerName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ProvideServices] [nvarchar](50) NULL,
	[Phone] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrintOrder]    Script Date: 10/31/2018 12:43:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrintOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductType] [nvarchar](50) NOT NULL,
	[Size] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[RequiredDate] [int] NOT NULL,
	[OrderDate] [int] NOT NULL,
 CONSTRAINT [PK_PrintOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PriOrderFulFill]    Script Date: 10/31/2018 12:43:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriOrderFulFill](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Size] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[RequiredDate] [int] NOT NULL,
	[OrderDate] [int] NOT NULL,
 CONSTRAINT [PK_ProductId] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
