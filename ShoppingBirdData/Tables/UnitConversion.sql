CREATE TABLE [dbo].[UnitConversion]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FromUnit] INT NOT NULL, 
    [ToUnit] INT NOT NULL, 
    [CalculationFactor] DECIMAL(13,4) NOT NULL, 
    CONSTRAINT [FK_UnitConversion_UnitFrom] FOREIGN KEY ([FromUnit]) REFERENCES [Unit](Id),
    CONSTRAINT [FK_UnitConversion_UnitTo] FOREIGN KEY ([ToUnit]) REFERENCES [Unit](Id)
)
