CREATE procedure [dbo].[SaveMandirDetails]
	@Id int,
	@Name varchar(150),
	@Address varchar(500),
	@CountryId int,
	@StateId int,
	@CityId int,
	@VillageId int,
	@PostalCode varchar(10),
	@PhoneNumber varchar(50),
	@Email varchar(50),
	@ImageUrl varchar(1000),
	@CreatedBy int,
	@RegistrationNumber nvarchar(100),
	@GurudevName nvarchar(500)

AS

BEGIN

	IF( @Id=0 )
	BEGIN
	
	 INSERT INTO [dbo].[Mandir]
	           ( Name
	           ,Address,CountryId
	           ,StateId,CityId,VillageId
	           ,PostalCode,PhoneNumber
	           ,Email,ImageUrl,CreatedBy,RegistrationNumber,GurudevName)
	     VALUES
	           (@Name
	           ,@Address,@CountryId
	           ,@StateId,@CityId,@VillageId
	           ,@PostalCode,@PhoneNumber
	           ,@Email,@ImageUrl ,@CreatedBy,@RegistrationNumber,@GurudevName)
	
	END
	ELSE
	BEGIN
	UPDATE [dbo].[Mandir]
	   SET Name = @Name,Address = @Address
	      ,CountryId = @CountryId ,StateId = @StateId
	      ,CityId = @CityId ,VillageId=@VillageId, PostalCode = @PostalCode
	      ,PhoneNumber = @PhoneNumber ,Email = @Email, ImageUrl = @ImageUrl 
	      ,UpdatedBy = @CreatedBy ,UpdatedOn = GETDATE(),
		  RegistrationNumber=@RegistrationNumber,GurudevName=@GurudevName
	WHERE Id = @id
	
	END


END
