CREATE TABLE [dbo].[Tax]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(50) NOT NULL, 
    [Rate] DECIMAL(3, 2) NOT NULL
)
