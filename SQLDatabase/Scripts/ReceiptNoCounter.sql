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
if not exists(select * from dbo.ReceiptNoCounter)
Begin
SET IDENTITY_INSERT dbo.ReceiptNoCounter ON 

INSERT dbo.ReceiptNoCounter (Id, BhetReceiptNo, ManorathReceiptNo, DarshanReceiptNo, IsDefaultRecord) VALUES (1, 0, 0, 0, 1)
SET IDENTITY_INSERT dbo.ReceiptNoCounter OFF
end