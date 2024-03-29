USE [OPS]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Size] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[RequiredDate] [int] NOT NULL,
	[OrderDate] [int] NOT NULL,
	[Heigth] [decimal](18, 0) NOT NULL,
	[Width] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ProductId] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialType]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialType](
	[MaterialTypID] [int] NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaterialType] PRIMARY KEY CLUSTERED 
(
	[MaterialTypID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DBoyDetail]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DBoyDetail](
	[DBoyID] [int] NOT NULL,
	[DBoyName] [nvarchar](50) NOT NULL,
	[DBAddress] [nvarchar](50) NOT NULL,
	[DBCity] [nvarchar](50) NOT NULL,
	[DBNic] [int] NOT NULL,
	[DBCountry] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DBoyDetail] PRIMARY KEY CLUSTERED 
(
	[DBoyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerData]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerData](
	[CustomerID] [int] NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Nic] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CustomerData] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[PersonId] [int] NOT NULL,
	[ContactTypeId] [int] NOT NULL,
	[ContactTypeName] [nvarchar](50) NOT NULL,
	[Contact] [int] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderMaster]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderMaster](
	[OrderId] [int] NOT NULL,
	[Size] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[RequiredDate] [int] NOT NULL,
	[OrderDate] [int] NOT NULL,
	[CltId] [int] NOT NULL,
	[PrinterId] [int] NOT NULL,
 CONSTRAINT [PK_PrintOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrinterReg]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrinterReg](
	[PrinterID] [int] NOT NULL,
	[OwnerName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Nic] [int] NOT NULL,
 CONSTRAINT [PK_PrinterReg] PRIMARY KEY CLUSTERED 
(
	[PrinterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/05/2018 11:58:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[PrinterRegShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[PrinterRegShowAll]

As
Begin

Select * from PrinterReg
End
GO
/****** Object:  StoredProcedure [dbo].[OrderMasterShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[OrderMasterShowAll]

As
Begin

Select * from OrderMaster
End
GO
/****** Object:  StoredProcedure [dbo].[OrderDetailShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[OrderDetailShowAll]

As
Begin

Select * from OrderDetail
End
GO
/****** Object:  StoredProcedure [dbo].[SP_ProductSearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_ProductSearch]
@ProductID int
As
Begin

Select * from Product where ProductID=@ProductID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_ProductDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ProductDelete]
@ProductID int
AS
Begin
Delete Product where ProductID=@ProductID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Product]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Product]
@ProductID int,
@ProductName nvarchar(50)
AS
BEGIN
	Insert into Product values (@ProductID,@ProductName)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_PrintRegUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_PrintRegUpdate]
@PrinterID int,
@OwnerName nvarchar(50),
@Nic int,
@City nvarchar(50),
@Country nvarchar(50),
@Address nvarchar(50)

As
Begin
Update PrinterReg set OwnerName=@OwnerName, Nic=@Nic, City=@City, Country=@Country,Address=@Address where PrinterID=@PrinterID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_PrinterRegSearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_PrinterRegSearch]
@PrinterID int
As
Begin

Select * from PrinterReg where PrinterID=@PrinterID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_PrinterRegDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_PrinterRegDelete]
@PrinterID int
AS
Begin
Delete PrinterReg where PrinterID=@PrinterID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_PoductUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_PoductUpdate]
@ProductID int,
@ProductName nvarchar(50)

As
Begin
Update Product set ProductName=@ProductName where ProductID=@ProductID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderMasterUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_OrderMasterUpdate]
@OrderId int,
@ProductId int,
@ProductType nvarchar(50),
@size int,
@Quantity int,
@Price int,
@RequiredDate int,
@OrderDate int,
@CltId int
As
Begin
Update OrderMaster set ProductID=@ProductId, Size=@size,Quantity=@Quantity, RequiredDate=@RequiredDate, OrderDate=@OrderDate, ProductType=@ProductType, CltId=@CltId where OrderID=@OrderId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderMasterSearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_OrderMasterSearch]
@OrderId int
As
Begin

Select * from OrderMaster where OrderId=@OrderId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderMasterDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OrderMasterDelete]
@OrderId int
AS
Begin
Delete OrderMaster where OrderId=@OrderId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderMaster]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_OrderMaster]
@OrderId int,
@Size int,
@Quantity int,
@Price int,
@RequiredDate int,
@OrderDate int,
@PrinterId int,
@CltId int
	
AS
BEGIN

Insert into OrderMaster values (@OrderId,@Size,@Quantity,@Price,@RequiredDate,@OrderDate,@PrinterId,@CltId)
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderDetailUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_OrderDetailUpdate]
@OrderId int,
@ProductId int,
@size int,
@Quantity int,
@Price int,
@RequiredDate int,
@OrderDate int,
@Heigth decimal(18,0),
@Width decimal(18,0)
As
Begin
Update OrderDetail set ProductId=@ProductId, Size=@size,Quantity=@Quantity, RequiredDate=@RequiredDate, OrderDate=@OrderDate, Heigth=@Heigth, Width=@width where OrderID=@OrderId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderDetailSearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_OrderDetailSearch]
@OrderId int
As
Begin

Select * from OrderDetail where OrderId=@OrderId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderDetailDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_OrderDetailDelete]
@OrderId int
AS
Begin
Delete OrderDetail where OrderId=@OrderId
End
GO
/****** Object:  StoredProcedure [dbo].[SP_OrderDetail]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_OrderDetail]
@OrderId int,
@ProductId int,
@Size int,
@Quantity int,
@Price int,
@OrderDate int,
@RequiredDate int,
@Heigth decimal(18,0),
@Width decimal(18,0)
	
AS
BEGIN
	INSERT into OrderDetail values (@OrderID,@ProductId,@Size,@Quantity,@Price,@OrderDate,@RequiredDate,@Heigth,@Width)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MaterialUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MaterialUpdate]
@MaterialTypID int,
@MaterialName nvarchar(50)

AS
BEGIN
  
  Update MaterialType set MaterialName=@MaterialName where MaterialTypID=@MaterialTypID

END
GO
/****** Object:  StoredProcedure [dbo].[SP_MaterialShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_MaterialShowAll]

As
Begin

Select * from MaterialType
End
GO
/****** Object:  StoredProcedure [dbo].[SP_MaterialSearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MaterialSearch]
@MaterialTypID int
AS
BEGIN
Select * from MaterialType where MaterialTypID=@MaterialTypID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_MaterialDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_MaterialDelete]
@MaterialTypeID int
AS
BEGIN
Delete MaterialType where MaterialTypID=@MaterialTypeID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DBoyUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DBoyUpdate]
@DBoyID int,
@DBoyName nvarchar(50),
@DBAddress nvarchar(50),
@DBCity nvarchar(50),
@DBNic int,
@DBCountry nvarchar(50)


AS
BEGIN
  
  Update DBoyDetail set DBoyName=@DBoyName,DBCity=@DBCity,DBCountry=@DBCountry,DBNic=@DBNic,DBAddress=@DBAddress where DBoyID=@DBoyID

END
GO
/****** Object:  StoredProcedure [dbo].[SP_DBoySearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DBoySearch]
@DBoyId int
AS
BEGIN
Select * from DBoyDetail where DBoyID=@DBoyId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DBoyDetailShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DBoyDetailShowAll]

AS
BEGIN
Select * from DBoyDetail
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DBoyDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DBoyDelete]
@DBoyID int
AS
BEGIN
Delete DBoyDetail where DBoyID=@DBoyID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CustUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CustUpdate]
@CustomerID int,
@CustomerName nvarchar(50),
@City nvarchar(50),
@Country nvarchar(50),
@Nic int,
@Address nvarchar(50)

AS
BEGIN
  
  Update CustomerData set CustomerName=@CustomerName,City=@City,Country=@Country,Nic=@Nic,Address=@Address where CustomerID=@CustomerID 

END
GO
/****** Object:  StoredProcedure [dbo].[SP_CustShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_CustShowAll]
AS
BEGIN
Select * from CustomerData
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CustDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CustDelete]
@CustomerID int
AS
BEGIN
Delete CustomerData where CustomerID=@CustomerID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ContactUpdate]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ContactUpdate]
@PersonId int,
@ContactTypeName nvarchar(50),
@ContactTypeId int,
@Contact int

AS
BEGIN
  
  Update Contact set PersonId=@PersonId,@ContactTypeName=@ContactTypeName,Contact=@Contact where ContactTypeId=@ContactTypeId

END
GO
/****** Object:  StoredProcedure [dbo].[SP_ContactShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_ContactShowAll]
AS
BEGIN
Select * from Contact
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ContactSearch]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ContactSearch]
@ContactTypeId int
AS
BEGIN
Select * from Contact where ContactTypeId=@ContactTypeId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ContactDelete]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ContactDelete]
@ContactTypeId int
AS
BEGIN
Delete Contact where ContactTypeId=@ContactTypeId
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddPrinterReg]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SP_AddPrinterReg]
@PrinterID int,
@OwnerName nvarchar(50),
@Address nvarchar (50),
@City nvarchar(50),
@Nic	int,	
@Country nvarchar(50)
	
AS
BEGIN
	INSERT into PrinterReg values (@PrinterID,@OwnerName,@Address,@City,@Nic,@Country)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddDBoyDetail]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddDBoyDetail]
@DBoyID int,
@DBoyName nvarchar(50),
@DBAddress nvarchar (50),
@DBCity nvarchar(50),
@DBNic	int,	
@DBCountry nvarchar(50)
	
AS
BEGIN
	INSERT into DBoyDetail values (@DBoyID,@DBoyName,@DBAddress,@DBCity,@DBNic,@DBCountry)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddCust]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddCust]
@CustomerID int,
@CustomerName nvarchar(50),
@Nic int,
@City nvarchar (50),
@Country nvarchar(50),
@Address nvarchar(50)
	
AS
BEGIN
	INSERT into CustomerData values (@CustomerID,@CustomerName,@Nic,@City,@Country,@Address)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_AddContact]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddContact]
@PersonId int,
@ContactTypeId int,
@ContactTypeName nvarchar (50),
@Contact int
	
AS
BEGIN
	INSERT into Contact values (@PersonId,@ContactTypeId,@ContactTypeName,@Contact)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Add1Material]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Add1Material]
@MaterialTypID int,
@MaterialName nvarchar(50)
	
AS
BEGIN
	INSERT into MaterialType values (@MaterialTypID,@MaterialName)
END
GO
/****** Object:  StoredProcedure [dbo].[ProductShowAll]    Script Date: 12/05/2018 11:58:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[ProductShowAll]

As
Begin

Select * from Product
End
GO
