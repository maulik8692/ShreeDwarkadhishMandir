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
  
 IF( @Id = 0 and isnull(@SupplierId,'') = '')  
 BEGIN  
   
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
   
    declare @DateTimeToSend datetime = GetDate(), @RequestNumber nvarchar(50)  
   
    set @Id = scope_identity();  
    Set @RequestNumber = 
	'S'+ RIGHT('000' + CONVERT(VARCHAR(11), 1) 
--+ replace(replace(replace(CONVERT( VARCHAR, GETDATE(), 120 ),'-',''),' ',''),':','')
, 25)
    Update S set S.SupplierId = @RequestNumber from Supplier as S where S.id=@Id   
     
    exec [SaveAccountHead] 
 @Id =  0
,@MandirId =  MandirId
,@GroupId =  0
,@AccountName =  SupplierName
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
,@CreatedBy = CreatedBy,
@AnnexureOrder = 0,
@AnnexureName =null
	--0,@MandirId,7,@SupplierName,0,@IsActive,@CreatedBy,null,null,null,null,null,null,null,null,null,@Id  
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
  
  exec SaveAccountHead @SupplierAccountHead,@MandirId,7,@SupplierName,0,@IsActive,@CreatedBy,null,null,null,null,null,null,null,null,null,@Id  
 END  
  
END  