﻿CREATE TABLE [dbo].[Invoice]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [StoreId] INT NOT NULL, 
    [Number] VARCHAR(50) NOT NULL /*Bill Number | Invoice Number etc...*/, 
    [AdjustAmount] DECIMAL(13,4)  NOT NULL, 
    [Total] DECIMAL(13,4)  NOT NULL, 
    [UserId] INT NOT NULL /*This is the Id of the application user. Not the sales assistant at the desk*/, 
    [Date] DATE NOT NULL, 
    CONSTRAINT [FK_Invoice_Store] FOREIGN KEY ([StoreId]) REFERENCES [Store]([Id]), 
    CONSTRAINT [FK_Invoice_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [AK_Invoice_InvoiceNumber] UNIQUE ([Number])
)
