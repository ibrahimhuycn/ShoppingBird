
USE ShoppingBirdData
GO
/*     
				Post-Deployment Script Template	
----------------------------------------------------------------------------------
1. Deleting prevoius data
----------------------------------------------------------------------------------
*/
DELETE FROM [dbo].[PriceList]
DELETE FROM [dbo].[InvoiceDetails]
DELETE FROM [dbo].[Invoice]
DELETE FROM [dbo].[Item]
DELETE FROM [dbo].[ItemCategory]
DELETE FROM [dbo].[Store]
DELETE FROM [dbo].[Tax]
DELETE FROM [dbo].[Unit]
GO
/*
2. Inserting data
-----------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Unit] ON
INSERT INTO [dbo].[Unit]([Id],[Unit],[Description]) VALUES (1,'ea','Each')
INSERT INTO [dbo].[Unit]([Id],[Unit],[Description]) VALUES (2,'Kg','Kilogram')
INSERT INTO [dbo].[Unit]([Id],[Unit],[Description]) VALUES (3,'g','gram')
SET IDENTITY_INSERT [Unit] OFF
GO

SET IDENTITY_INSERT [dbo].[Tax] ON
INSERT INTO [dbo].[Tax]([Id],[Description],[Rate]) VALUES (1,'GST 6%','0.06')
INSERT INTO [dbo].[Tax]([Id],[Description],[Rate]) VALUES (2,'No Tax','0.00')
SET IDENTITY_INSERT [dbo].[Tax] OFF
GO

SET IDENTITY_INSERT [dbo].[Store] ON
INSERT INTO [dbo].[Store]([Id],[Name],[IsTaxInclusive]) VALUES (1,'Asni Mini Mart',1)
INSERT INTO [dbo].[Store]([Id],[Name],[IsTaxInclusive]) VALUES (2,'Stop and Shop',0)
INSERT INTO [dbo].[Store]([Id],[Name],[IsTaxInclusive]) VALUES (3,'Seeds',1)
INSERT INTO [dbo].[Store]([Id],[Name],[IsTaxInclusive]) VALUES (4,'Samraahi',0)
SET IDENTITY_INSERT [dbo].[Store] OFF
GO

SET IDENTITY_INSERT [dbo].[ItemCategory] ON
INSERT INTO [dbo].[ItemCategory]([Id],[Category]) VALUES (1,'Fruits and Vegetables')
INSERT INTO [dbo].[ItemCategory]([Id],[Category]) VALUES (2,'Clothes')
INSERT INTO [dbo].[ItemCategory]([Id],[Category]) VALUES (3,'Electrnics')
INSERT INTO [dbo].[ItemCategory]([Id],[Category]) VALUES (4,'Bottled Foods')
INSERT INTO [dbo].[ItemCategory]([Id],[Category]) VALUES (5,'Others')
SET IDENTITY_INSERT [dbo].[ItemCategory] OFF
GO

SET IDENTITY_INSERT [dbo].[Item] ON
INSERT INTO [dbo].[Item]([Id],[Description],[CategoryId],[SubCategoryId]) VALUES (1,'Safa Chef Chili Sauce Garlic 340g',4,4)
INSERT INTO [dbo].[Item]([Id],[Description],[CategoryId],[SubCategoryId]) VALUES (2,'Stell Air Freshner Packet Rose',5,5)
INSERT INTO [dbo].[Item]([Id],[Description],[CategoryId],[SubCategoryId]) VALUES (4,'Sony batter AA',3,3)
SET IDENTITY_INSERT [dbo].[Item] OFF
GO

SET IDENTITY_INSERT [dbo].[PriceList] ON

INSERT INTO [dbo].[PriceList] ([Id],[ItemId],[Barcode],[TaxId],[StoreId],[RetailPrice],[UnitId],[UpdatedAt],[CreatedAt]) 
VALUES (1,1,'1234',1,3,16.98,1,'20190101','20190101')

INSERT INTO [dbo].[PriceList] ([Id],[ItemId],[Barcode],[TaxId],[StoreId],[RetailPrice],[UnitId],[UpdatedAt],[CreatedAt]) 
VALUES (2,2,'5678',1,3,18.00,1,'20190101','20190101')

SET IDENTITY_INSERT [dbo].[PriceList] OFF
