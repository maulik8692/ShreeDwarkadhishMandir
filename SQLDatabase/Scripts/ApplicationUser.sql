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
if not exists(select * from dbo.ApplicationUser)
Begin
SET IDENTITY_INSERT dbo.ApplicationUser ON 

INSERT dbo.ApplicationUser (Id, DisplayName, UserName, Password, Address, Email, PhoneNumber, MandirId, UserTypeId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, DeletedBy, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (1, N'Vallabhacharya', N'Vallabh', N'WbpUDG/D0M0WYuDV40jTlA==', NULL, NULL, NULL, 1, 1, 0, GETDATE(), NULL, NULL, NULL, NULL, 0, 1)

INSERT dbo.ApplicationUser (Id, DisplayName, UserName, Password, Address, Email, PhoneNumber, MandirId, UserTypeId, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, DeletedBy, DeletedOn, IsDeleted, IsDefaultRecord) 
VALUES (2, N'System Admin', N'admin', N'WbpUDG/D0M0WYuDV40jTlA==', N'System Admin', N'System@Admin.com', N'0123456789', 1, 2, 0, GETDATE(), NULL, NULL, NULL, NULL, 0, 1)

SET IDENTITY_INSERT dbo.ApplicationUser OFF
end