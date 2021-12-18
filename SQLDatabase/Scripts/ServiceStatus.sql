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
if not exists(select * from dbo.ServiceStatus)
Begin
SET IDENTITY_INSERT dbo.ServiceStatus ON 

INSERT dbo.ServiceStatus (Id, ServiceName, IsRunning, TimeInterval, IsActive, IsDefaultRecord) 
VALUES (1, N'EmailSender', 0, 1000, 1, 1)
SET IDENTITY_INSERT dbo.ServiceStatus OFF
end