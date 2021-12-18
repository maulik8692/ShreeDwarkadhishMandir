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
if not exists(select * from dbo.UserType)
Begin
SET IDENTITY_INSERT dbo.UserType ON 

INSERT dbo.UserType (Id, TypeName, CreadedOn, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (1, N'Vallabhkul', GETDATE(), NULL, 0, 1)
INSERT dbo.UserType (Id, TypeName, CreadedOn, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (2, N'System Admin', GETDATE(), NULL, 0, 1)
INSERT dbo.UserType (Id, TypeName, CreadedOn, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (3, N'Adhikariji', GETDATE(), NULL, 0, 1)
INSERT dbo.UserType (Id, TypeName, CreadedOn, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (4, N'Mukhyaji',GETDATE(), NULL, 0, 1)
INSERT dbo.UserType (Id, TypeName, CreadedOn, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (5, N'Samadhani',GETDATE(), NULL, 0, 1)
INSERT dbo.UserType (Id, TypeName, CreadedOn, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (6, N'Bhandari',GETDATE(), NULL, 0, 1)
SET IDENTITY_INSERT dbo.UserType OFF
END