CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Description] VARCHAR(100) NOT NULL, 
    CONSTRAINT [AK_Item_Description] UNIQUE ([Description]), 
    CONSTRAINT [PK_Item] PRIMARY KEY ([Id]) 

)
