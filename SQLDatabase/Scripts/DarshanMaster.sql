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
if not exists(select * from dbo.DarshanMaster)
Begin
SET IDENTITY_INSERT dbo.DarshanMaster ON 

INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (1, N'Mangla', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (2, N'Shringar', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (3, N'Gwal', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (4, N'Rajbhog', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (5, N'Uthapan', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (6, N'Bhog', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (7, N'Aarti', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (8, N'Shayan', 1, 1)
INSERT dbo.DarshanMaster (Id, Darshan, IsActive, IsDefaultRecord) VALUES (9, N'Other', 1, 1)
SET IDENTITY_INSERT dbo.DarshanMaster OFF
end