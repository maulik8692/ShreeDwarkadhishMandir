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
if not exists(select * from dbo.Store)
Begin
SET IDENTITY_INSERT dbo.Store ON 

INSERT dbo.Store (Id, MandirId, Name, Description, IsActive, IsMainStore, StoreType, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (1, 1, N'Bhandar Ghar', N'Bhandar Ghar', 1, 1, 1, GETDATE(), 1, NULL, NULL, NULL, NULL, 0, 1)
INSERT dbo.Store (Id, MandirId, Name, Description, IsActive, IsMainStore, StoreType, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (2, 1, N'Rasoi Ghar', N'Rasoi Ghar', 1, 1, 2, GETDATE(), 1, NULL, NULL, NULL, NULL, 0, 1)
INSERT dbo.Store (Id, MandirId, Name, Description, IsActive, IsMainStore, StoreType, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (3, 1, N'Bhet Ghar', N'', 1, 1, 3, GETDATE(), 1, NULL, NULL, NULL, NULL, 0, 1)
INSERT dbo.Store (Id, MandirId, Name, Description, IsActive, IsMainStore, StoreType, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (4, 1, N'Store Room', N'Store Room', 1, 0, 0, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)
SET IDENTITY_INSERT dbo.Store OFF
END