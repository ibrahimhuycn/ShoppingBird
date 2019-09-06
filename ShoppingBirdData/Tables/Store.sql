CREATE TABLE [dbo].[Store]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [IsTaxInclusive] BIT NOT NULL
)
