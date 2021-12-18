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
if not exists(select * from dbo.Mandir)
Begin
SET IDENTITY_INSERT dbo.Mandir ON 

INSERT dbo.Mandir (Id, Name, ImageUrl, Address, CountryId, StateId, CityId, VillageId, PostalCode, PhoneNumber, Email, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn, DeletedBy, DeletedOn, IsDeleted, RegistrationNumber, GurudevName, MandirHeader, IsDefaultRecord) 
VALUES (1, N'Shree Dwarkadhish Mandir ', N'https://drive.google.com/uc?id=1ZhOZjaTbw-dUyG4Ia1yQraClzCVx_cWj', N'Bahuva Ni Pole, Raipur Chakla', 101, 12, 133, 620031, N'380001', N'079 22141537', N'dwarkadhishraipur@gmail.com', 2, GETDATE(), null, null, NULL, NULL, 0, N'A 1954', N'ગોસ્વામી શ્રી વ્રજેશકુમારેજી મહારાજશ્રી (કાંકરોલી)', N'श्री द्वारकेशो जयती', 1)
SET IDENTITY_INSERT dbo.Mandir OFF
END