CREATE TABLE [dbo].[GPUCard]
(
	[GPUCardID] INT IDENTITY (1,1) NOT NULL, 
    [ChipsetID] INT NOT NULL,
    [ManufactureID] INT NOT NULL, 
	[Price] DECIMAL(10, 2) NOT NULL, 
	[MemoryType] NVARCHAR(50) NOT NULL,
	[Memory] NVARCHAR(50) NOT NULL,
	[ClockSpeed] NVARCHAR(50) NOT NULL,
	[ImageLink] NVARCHAR(1000) NULL,
	[ReleaseDate] Date NULL,
	PRIMARY KEY CLUSTERED ([GPUCardID] ASC),
	CONSTRAINT [FK_dbo.GPUCard_dbo.Manufacturer_ManufactureID] FOREIGN KEY ([ManufactureID]) 
        REFERENCES [dbo].[Manufacturer] ([ManufactureID]) ON DELETE CASCADE,
	CONSTRAINT [FK_dbo.GPUCard_dbo.ChipSet_ChipsetID] FOREIGN KEY ([ChipsetID]) 
        REFERENCES [dbo].[Chipset] ([ChipsetID]) ON DELETE CASCADE, 
)
