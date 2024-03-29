﻿CREATE TABLE [dbo].[PriceList]
(
	[Id] INT NOT NULL  IDENTITY(1,1), 
    [ItemId] INT NOT NULL,
	[Barcode] VARCHAR(50) NOT NULL,
    [StoreId] INT NOT NULL, 
    [RetailPrice] DECIMAL(13,4) NOT NULL, 
    [UnitId] INT NOT NULL, 
    [UpdatedAt] DATE NOT NULL, 
    [CreatedAt] DATE NOT NULL, 
    CONSTRAINT [FK_PriceList_Item] FOREIGN KEY ([ItemId]) REFERENCES [Item]([Id]), 
    CONSTRAINT [FK_PriceList_Store] FOREIGN KEY ([StoreId]) REFERENCES [Store]([Id]), 
    CONSTRAINT [FK_PriceList_Unit] FOREIGN KEY ([UnitId]) REFERENCES [Unit]([Id]), 
    CONSTRAINT [PK_PriceList] PRIMARY KEY ([Id],[Barcode])
)
