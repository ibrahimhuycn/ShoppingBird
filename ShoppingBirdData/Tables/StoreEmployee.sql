CREATE TABLE [dbo].[StoreEmployee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [StoreId] INT NOT NULL, 
    [DesignationId] INT NOT NULL, 
    CONSTRAINT [FK_StoreEmployee_Desigation] FOREIGN KEY ([DesignationId]) REFERENCES [Designation]([Id]), 
    CONSTRAINT [FK_StoreEmployee_ToStore] FOREIGN KEY ([StoreId]) REFERENCES [Store]([Id]), 
    CONSTRAINT [FK_StoreEmployee_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
