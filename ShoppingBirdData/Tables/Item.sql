CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(100) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [SubCategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Item_ItemCategory] FOREIGN KEY ([CategoryId]) REFERENCES [ItemCategory]([Id]),
	CONSTRAINT [FK_Item_ItemSubCategory] FOREIGN KEY ([CategoryId]) REFERENCES [ItemCategory]([Id]) 

)
