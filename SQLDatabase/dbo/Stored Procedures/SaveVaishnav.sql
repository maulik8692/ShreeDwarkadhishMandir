-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,05-Sep-2018>  
-- Description: <Description,,SaveVaishnav>  
-- =============================================  
CREATE PROCEDURE [dbo].[SaveVaishnav]  
 @Id int,  
 @MobileNo varchar(15)= null,  
 @Address nvarchar(1000) = null,  
 @AddtionalNote nvarchar(1000)= null,  
 @BloodGroup varchar(10)= null,  
 @CityId int= null,  
 @CountryId int= null,  
 @DateOfBirth datetime= null,  
 @Email varchar(50)= null,  
 @FirstName nvarchar(100)= null,  
 @Gender varchar(20)= null,  
 @LastName varchar(20)= null,  
 @MaritalStatus varchar(20)= null,  
 @MiddleName nvarchar(100)= null,  
 @Nickname nvarchar(100)= null,  
 @Occupation int= null,  
 @OccupationAddress nvarchar(1000)= null,  
 @OccupationCityId int= null,  
 @OccupationCountryId int= null,  
 @OccupationDetail nvarchar(1000)= null,   
 @OccupationStateId int= null,  
 @OccupationVillageId int= null,  
 @OccupationPostalCode nvarchar(100)= null,  
 @OfficePhone varchar(25)= null,  
 @ResidencePhone varchar(20)= null,  
 @StateId int= null,  
 @VillageId int= null,  
 @PostalCode nvarchar(50)= null,  
 @IsActive bit= null,  
 @CreatedBy int  
  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
     
IF(@Id = 0 )  
BEGIN  
  
 INSERT INTO dbo.Vaishnav  
           (FirstName,MiddleName  
           ,LastName,Nickname  
           ,Address,CountryId  
           ,StateId,CityId  
           ,VillageId,PostalCode  
           ,Gender,MaritalStatus  
           ,DateOfBirth,BloodGroup  
           ,MobileNo,Email  
           ,ResidencePhone,Occupation  
           ,OccupationDetail,OccupationAddress  
           ,OccupationCountryId,OccupationStateId  
           ,OccupationCityId,OccupationVillageId  
           ,OccupationPostalCode,OfficePhone  
           ,AddtionalNote,IsActive  
           ,CreatedBy)  
     VALUES  
           (@FirstName,@MiddleName  
           ,@LastName,@Nickname  
           ,@Address,@CountryId  
           ,@StateId,@CityId  
           ,@VillageId,@PostalCode  
           ,@Gender,@MaritalStatus  
           ,@DateOfBirth,@BloodGroup  
           ,@MobileNo,@Email  
           ,@ResidencePhone,@Occupation  
           ,@OccupationDetail,@OccupationAddress  
           ,@OccupationCountryId,@OccupationStateId  
           ,@OccupationCityId,@OccupationVillageId  
           ,@OccupationPostalCode,@OfficePhone  
           ,@AddtionalNote,@IsActive  
           ,@CreatedBy)  
       
	   declare @DateTimeToSend datetime = GetDate(),  
 @VaishnavId int = scope_identity()  
  
 Update V set V.VaishnavId = dbo.GenerateVaishnavId(@VaishnavId) from Vaishnav as V where V.id=@VaishnavId  

      
IF( ISNULL(@Email,'')<>'' )  
BEGIN  
  
     exec SaveEmailLog @Id = 0,  
       @EmailId = @Email,  
       @Status = 'Pending',  
       @Type = 'Registration',  
       @DateTimeToSend = @DateTimeToSend ,  
       @VaishnavId = @VaishnavId,@ReceiptId=null,@PadhramaniId=null,@PadhramaniStatus=null  
  
  
END  
  
  
END  
else  
  
BEGIN IF(@Id > 0 )  
  
UPDATE dbo.Vaishnav  
   SET FirstName = @FirstName ,MiddleName = @MiddleName   
      ,LastName = @LastName ,Nickname = @Nickname   
      ,Address = @Address ,CountryId = @CountryId   
      ,StateId = @StateId ,CityId = @CityId   
      ,VillageId = @VillageId ,PostalCode = @PostalCode   
      ,Gender = @Gender ,MaritalStatus = @MaritalStatus  
      ,DateOfBirth = @DateOfBirth ,BloodGroup = @BloodGroup   
      ,MobileNo = @MobileNo ,Email = @Email   
      ,ResidencePhone = @ResidencePhone ,Occupation = @Occupation   
      ,OccupationDetail = @OccupationDetail ,OccupationAddress = @OccupationAddress   
      ,OccupationCountryId = @OccupationCountryId ,OccupationStateId = @OccupationStateId   
      ,OccupationCityId = @OccupationCityId ,OccupationVillageId = @OccupationVillageId   
      ,OccupationPostalCode = @OccupationPostalCode  
      ,OfficePhone = @OfficePhone ,AddtionalNote = @AddtionalNote   
      ,IsActive = @IsActive  
      ,UpdatedOn = GETDATE(),UpdatedBy = @CreatedBy  
        
 WHERE Id= @id  
  
END  
  
END  