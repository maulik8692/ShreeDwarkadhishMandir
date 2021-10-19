CREATE procedure [dbo].[GetMandirById]
	@Id int
AS 
BEGIN
 Select Id,Name,Address,CountryId,StateId,CityId,VillageId,PostalCode,PhoneNumber,Email,ImageUrl,GurudevName,RegistrationNumber from Mandir
 where Id= @Id
END
