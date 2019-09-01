CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(100) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [SubCategoryId] INT NOT NULL 
)
