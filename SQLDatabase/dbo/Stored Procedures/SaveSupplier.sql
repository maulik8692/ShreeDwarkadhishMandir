-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,18-oct-2018>  
-- Description: <Description,,GetSuppliers>  
-- GetSuppliers 1,100  
-- =============================================  
CREATE PROCEDURE [dbo].[SaveSupplier]  
  @Id int  
 ,@MandirId int  
 ,@SupplierId varchar(50)  
 ,@SupplierName varchar(50)  
 ,@Address varchar(500)  
 ,@CountryId int  
 ,@StateId int  
 ,@CityId int  
 ,@VillageId int  
 ,@PostalCode varchar(50)  
 ,@MobileNo varchar(50)  
 ,@Email varchar(50)  
 ,@CreatedBy int  
 ,@IsActive bit  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
BEGIN try
BEGIN TRANSACTION
	

	IF( @Id = 0 and isnull(@SupplierId,'') = '')  
	BEGIN  
	   declare @DateTimeToSend datetime = GetDate(), @RequestNumber nvarchar(50),
			@GroupId Int
		INSERT INTO dbo.Supplier  
	(MandirId  
	,SupplierName  
	,Address  
	,CountryId  
	,StateId  
	,CityId  
	,VillageId  
	,PostalCode  
	,MobileNo  
	,Email  
	,CreatedBy  
	,IsActive)  
	VALUES  
	(@MandirId  
	,@SupplierName  
	,@Address  
	,@CountryId  
	,@StateId  
	,@CityId  
	,@VillageId  
	,@PostalCode  
	,@MobileNo  
	,@Email  
	,@CreatedBy  
	,@IsActive)  
   
		set @Id = scope_identity();  
		Set @RequestNumber = 
		'S'+ RIGHT('000' + CONVERT(VARCHAR(11), 1) 
		--+ replace(replace(replace(CONVERT( VARCHAR, GETDATE(), 120 ),'-',''),' ',''),':','')
		, 25)
		Update S set S.SupplierId = @RequestNumber from Supplier as S where S.id=@Id   
    
		select Top 1 @GroupId=AG.Id from AccountGroup as AG
		join DefaultGroups as DG on DG.Id=AG.DefaultGroupId
		and DG.NatureOfGroup = 'Expenses' and DG.GroupName = 'Purchase Account' and AG.IsDelete=0 and AG.IsActive=1

		exec [SaveAccountHead] 
		 @Id =  0
		,@MandirId =  @MandirId
		,@GroupId =  @GroupId
		,@AccountName =  @SupplierName
		,@Alias =  @RequestNumber
		,@BalanceAmount = 0.00  
		,@DebitCredit = 'Debit'  
		,@AccountHolderName =  Null  
		,@BankName =  null  
		,@BankAddress  = null  
		,@AccountNumber =  null  
		,@IFSCCode =  null  
		,@BankBranch = null  
		,@DateOfIssue = null  
		,@DateOfMaturity = null  
		,@InterestRate = null
		,@MaturityAmount = null
		,@IsEditable = 0 
		,@IsActive = 1
		,@CreatedBy = @CreatedBy
		,@AnnexureOrder = 0
		,@AnnexureName =null
		,@SupplierId = @Id
	END  
	ELSE IF( @Id <> 0 and isnull(@SupplierId,'') <> '')  
	BEGIN  
		Update S set   
		 MandirId=@MandirId    
		,SupplierName=@SupplierName  
		,Address =@Address  
		,CountryId=@CountryId  
		,StateId=@StateId  
		,CityId=@CityId  
		,VillageId=@VillageId  
		,PostalCode=@PostalCode  
		,MobileNo=@MobileNo  
		,Email=@Email  
		,UpdatedBy=@CreatedBy  
		,UpdatedOn=GETDATE()  
		,IsActive=@IsActive  
		from Supplier as S   
		where S.id=@Id and S.SupplierId=@SupplierId  
   
		Declare @SupplierAccountHead int;  
		Select @SupplierAccountHead=Id from AccountHead where SupplierId=@Id  
	
		IF( isnull(@SupplierAccountHead,0) > 0 )
		BEGIN

			exec [SaveAccountHead] 
			 @Id =  @SupplierAccountHead
			,@MandirId =  @MandirId
			,@GroupId =  @GroupId
			,@AccountName =  @SupplierName
			,@Alias =  @SupplierId
			,@BalanceAmount = 0.00  
			,@DebitCredit = 'Debit'  
			,@AccountHolderName =  Null  
			,@BankName =  null  
			,@BankAddress  = null  
			,@AccountNumber =  null  
			,@IFSCCode =  null  
			,@BankBranch = null  
			,@DateOfIssue = null  
			,@DateOfMaturity = null  
			,@InterestRate = null
			,@MaturityAmount = null
			,@IsEditable = 0 
			,@IsActive = @IsActive
			,@CreatedBy = @CreatedBy
			,@AnnexureOrder = 0
			,@AnnexureName =null
			,@SupplierId = @Id 

		END
	END  
COMMIT TRANSACTION
END try
BEGIN Catch
BEGIN
	ROLLBACK TRANSACTION
END
END Catch
END  