CREATE TABLE [dbo].[Chipset]
(
	[ChipsetID] INT IDENTITY (1,1) NOT NULL, 
    [ChipsetName] NVARCHAR(50) NOT NULL, 
	PRIMARY KEY CLUSTERED ([ChipsetID] ASC),
)
