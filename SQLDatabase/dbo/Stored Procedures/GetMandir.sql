CREATE procedure [dbo].[GetMandir]
AS

BEGIN

 Select Id,Name,Address,CountryId,StateId,CityId,VillageId,PostalCode,PhoneNumber,Email,ImageUrl,GurudevName,RegistrationNumber from Mandir

END
