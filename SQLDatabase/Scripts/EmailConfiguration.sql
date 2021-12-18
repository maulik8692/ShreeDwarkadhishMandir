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
if not exists(select * from dbo.EmailConfiguration)
Begin
SET IDENTITY_INSERT dbo.EmailConfiguration ON 

INSERT dbo.EmailConfiguration 
(Id, Server, Port, Username, Password, DisplayName, SSL, ExchangeService, IsActive, IsDefaultRecord)
VALUES 
(1, N'smtp.gmail.com', 587, N'dwarkadhishraipur@gmail.com', N'Maulik@123', N'Shree Dwarkadhish Mandir Raipur', 1, 0, 1, 1)
SET IDENTITY_INSERT dbo.EmailConfiguration OFF
end