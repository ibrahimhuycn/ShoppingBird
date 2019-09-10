CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FullName] VARCHAR(100) NOT NULL, 
    [IsStoreEmployee] BIT NOT NULL, 
    [Username] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(100) NOT NULL, 
    [Phone] INT NOT NULL, 
    [Hash] VARCHAR(200) NOT NULL /*This should be a Char field since the Hash would be fixed length */, 
    [RequirePasswordChange] BIT NOT NULL
)
