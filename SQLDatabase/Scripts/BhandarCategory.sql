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
if not exists(select * from dbo.BhandarCategory)
Begin
SET IDENTITY_INSERT dbo.BhandarCategory ON 

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (2, 1, N'Gold Jewellery', NULL, NULL, 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (3, 2, N'Dudhghar', N'Dudhghar', N'Dudhghar', 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (4, 2, N'Nagari', N'Nagari', N'Nagari', 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (5, 2, N'An-Sakhadi', N'An-Sakhadi', N'An-Sakhadi', 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (6, 2, N'Sakhadi', N'Sakhadi', N'Sakhadi', 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (7, 3, N'Kachi Samagri', N'Kachi Samagri', N'Kachi Samagri', 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (8, 3, N'Tokari', N'Tokari', N'Tokari', 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.BhandarCategory (Id, GroupId, Name, CategoryCode, Description, IsActive, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, DeletedOn, DeletedBy, IsDeleted, IsDefaultRecord) 
VALUES (9, 4, N'Wooden Stock', NULL, NULL, 1, GETDATE(), 2, NULL, NULL, NULL, NULL, 0, 1)

SET IDENTITY_INSERT dbo.BhandarCategory OFF
END