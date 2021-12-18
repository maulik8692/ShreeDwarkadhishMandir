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
if not exists(select * from dbo.BhandarGroup)
Begin
SET IDENTITY_INSERT dbo.BhandarGroup ON 

INSERT dbo.BhandarGroup (Id, MandirId, Name, GroupCode, Description, GroupType, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (1, 1, N'Jewellery Sringar', NULL, NULL, 1, 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarGroup (Id, MandirId, Name, GroupCode, Description, GroupType, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (2, 1, N'Samagri', NULL, NULL, 2, 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarGroup (Id, MandirId, Name, GroupCode, Description, GroupType, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (3, 1, N'Kacha Bhandar', NULL, NULL, 3, 1, GETDATE(), 2,  NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarGroup (Id, MandirId, Name, GroupCode, Description, GroupType, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (4, 1, N'Moveable Stock', NULL, NULL, 0, 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)
SET IDENTITY_INSERT dbo.BhandarGroup OFF
END