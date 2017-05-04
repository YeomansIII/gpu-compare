/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Manufacturer AS Target 
USING (VALUES 
        (1, 'Nvidia'), 
        (2, 'AMD'),
		(3, 'GIGABYTE'),
		(4, 'EVGA')
) 
AS Source (ManufactureID, ManufacturerName) 
ON Target.ManufactureID = Source.ManufactureID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (ManufacturerName) 
VALUES (ManufacturerName);

MERGE INTO Chipset AS Target 
USING (VALUES 
        (1,'GeForce GTX 1070'),
		(2,'GeForce GTX 1080')
) 
AS Source (ChipsetID, ChipsetName) 
ON Target.ChipsetID = Source.ChipsetID 
WHEN NOT MATCHED BY TARGET THEN 
INSERT (ChipsetName) 
VALUES (ChipsetName);

MERGE INTO GPUCard AS Target
USING (VALUES 
        (1, 1, 3, 359.00, 'GDDR5', '8,192', '1,506', '', '2013-09-01')
)
AS Source (GPUCardID, ChipsetID, ManufactureID, Price, MemoryType, Memory, ClockSpeed, ImageLink, ReleaseDate)
ON Target.GPUCardID = Source.GPUCardID
WHEN NOT MATCHED BY TARGET THEN
INSERT (ChipsetID, ManufactureID, Price, MemoryType, Memory, ClockSpeed, ImageLink, ReleaseDate)
VALUES (ChipsetID, ManufactureID, Price, MemoryType, Memory, ClockSpeed, ImageLink, ReleaseDate);