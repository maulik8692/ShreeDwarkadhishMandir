/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM $(TableName)					
--------------------------------------------------------------------------------------
*/
if not exists(select * from dbo.UnitOfMeasurement)
Begin
SET IDENTITY_INSERT dbo.UnitOfMeasurement ON 

INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (1, N'mm', N'millimeters', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (2, N'cm', N'centimeter', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (3, N'm', N'meter', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (4, N'mg', N'milligram', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (5, N'g', N'gram', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (6, N'kg', N'kilogram', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (7, N'L', N'liter', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (8, N'ml', N'milliliter', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (9, N'DZ', N'Dozen', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (10, N'NOS', N'NOS', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (11, N'IN', N'Inches', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (12, N'PK100', N'Pack 100', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (13, N'PK 10', N'Pack 10', 1, GETDATE(), 2, NULL, NULL, 1, 1)
INSERT dbo.UnitOfMeasurement (Id, UnitAbbreviation, UnitDescription, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, MandirId, IsDefaultRecord) 
VALUES (14, N'PK 50', N'Pack 50', 1, GETDATE(), 2, NULL, NULL, 1, 1)
SET IDENTITY_INSERT dbo.UnitOfMeasurement OFF
END
