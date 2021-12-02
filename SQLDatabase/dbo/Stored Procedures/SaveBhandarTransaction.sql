-- =============================================            
-- Author:  <Author,,Maulik Shah>            
-- Create date: <Create Date,,21-Aug-2018>            
-- Description: <Description,,SaveBhandarTransaction>            
-- =============================================            
CREATE PROCEDURE [dbo].[SaveBhandarTransaction]            
 @BhandarId int          
,@StoreId int          
,@BhandarTransactionCodeId int          
,@UnitId int          
,@SupplierId int = null         
,@SamagriId int = null         
,@AccountHeadId int  = null        
,@StockTransactionQuantity decimal(18,5)  = 0        
,@Price decimal(18,2)  = 0        
,@Description nvarchar(1000) = null    
,@VaishnavId int = null    
,@CreatedBy int    
,@IncomeAccountId int  = null    
,@ExpensesAccountId int  = null,    
 @ChequeBank varchar(50) = null,            
 @ChequeBranch varchar(50) = null,            
 @ChequeNumber varchar(50) = null,            
 @ChequeDate datetime =  null,            
 @ChequeStatus int =  null,  
 @TransactionId uniqueidentifier  
 ,@ReceiptId int = null
 ,@ApplicationUser int = null
AS            
BEGIN            
 -- SET NOCOUNT ON added to prevent extra result sets from            
 -- interfering with SELECT statements.            
 SET NOCOUNT ON;            
            
 BEGIN TRANSACTION;            
  BEGIN TRY             
 Declare @TransactionDate datetime = Getdate();    
 if (isnull(@SupplierId,0) = 0) set @SupplierId = null          
 if (isnull(@SamagriId,0) = 0) set @SamagriId = null         
 if (isnull(@AccountHeadId,0) = 0) set @AccountHeadId = null       
 if (isnull(@VaishnavId,0) = 0) set @VaishnavId = null    
 if (isnull(@IncomeAccountId,0) = 0) set @IncomeAccountId = null    
 if (isnull(@ExpensesAccountId,0) = 0) set @ExpensesAccountId = null  
 if (isnull(@ReceiptId,0) = 0) set @ReceiptId = null  
 if (isnull(@ApplicationUser,0) = 0) set @ApplicationUser = null  
    
 DECLARE @IdentityValue AS TABLE(ID INT);         
 Declare @Id int = 0,@BhandarUnitId int;      
        
 select @BhandarUnitId=UnitId from Bhandar as B with (nolock) where B.Id=@BhandarId        
        
 INSERT INTO dbo.BhandarTransaction          
 (BhandarId,StoreId,BhandarTransactionCodeId,UnitId,SupplierId,SamagriId,AccountHeadId,      
  StockTransactionQuantity, Price,Description,CreatedBy,OriginalUnitId,VaishnavId,IncomeAccountId,ExpensesAccountId,TransactionId  
  ,ReceiptId,ApplicationUser)         
 OUTPUT Inserted.ID INTO @IdentityValue             
 VALUES          
  (@BhandarId,@StoreId,@BhandarTransactionCodeId,@BhandarUnitId,@SupplierId,@SamagriId,@AccountHeadId,        
  isnull(dbo.UnitConversionFormula(@BhandarId,@UnitId,@StockTransactionQuantity),0),          
  @Price,@Description,@CreatedBy,@UnitId,@VaishnavId,@IncomeAccountId,@ExpensesAccountId,@TransactionId,@ReceiptId
  ,@ApplicationUser)          
         
 select @Id = ID  FROM @IdentityValue           
        
 ;WITH SP    
 AS              
 (              
  select Sum(BT.StockTransactionQuantity * BC.MultiplicationWith) Balance,BT.BhandarId        
  from BhandarTransaction as BT with (nolock)        
  join BhandarTransactionCode as BC on BC.Id=BT.BhandarTransactionCodeId        
  and BT.BhandarId= @BhandarId        
  group by BT.BhandarId          
 )           
 Update B set B.Balance=SP.Balance         
 from Bhandar as B         
 Join SP on SP.BhandarId=B.Id        
      
 if not exists (select * from BhandarStoreBalance where BhandarId=@BhandarId and StoreId=@StoreId)      
 BEGIN      
 ;WITH SP    
  AS              
  (              
   select Sum(BT.StockTransactionQuantity * BC.MultiplicationWith) Balance,BT.BhandarId,BT.StoreId        
   from BhandarTransaction as BT with (nolock)        
   join BhandarTransactionCode as BC on BC.Id=BT.BhandarTransactionCodeId        
   and BT.BhandarId= @BhandarId and BT.StoreId=@StoreId      
   group by BT.BhandarId ,BT.StoreId       
  )       
  insert into BhandarStoreBalance      
  (BhandarId,StoreId,UnitId,Balance)      
  select       
   SP.BhandarId,SP.StoreId,@BhandarUnitId,SP.Balance       
  from SP      
 END      
 else      
 BEGIN      
 ;WITH SP    
  AS              
  (              
  select Sum(BT.StockTransactionQuantity * BC.MultiplicationWith) Balance,BT.BhandarId,BT.StoreId        
   from BhandarTransaction as BT with (nolock)        
   join BhandarTransactionCode as BC on BC.Id=BT.BhandarTransactionCodeId        
   and BT.BhandarId= @BhandarId and BT.StoreId=@StoreId      
   group by BT.BhandarId ,BT.StoreId           
  )           
  Update B set B.Balance=SP.Balance         
  from BhandarStoreBalance as B         
  Join SP on SP.BhandarId=B.BhandarId and SP.StoreId=B.StoreId      
 END      
     
     
IF( @BhandarTransactionCodeId = 2 )    
BEGIN    
    
exec MultipleAccountTransaction             
 @CreditAccountId = @IncomeAccountId,                  
 @DebitAccountId = @ExpensesAccountId,                  
 @TransactionAmount = @Price,                  
 @TransactionDate = @TransactionDate,                  
 @VaishnavId  = null,                   
 @CreatedBy =@CreatedBy,                  
 @ManorathReceiptId =  null,                  
 @ManorathId = null,                  
 @VoucherId  =  null,                  
 @PaymentId = null,                  
 @TrasactionType  =  null,                  
 @ChequeBank  = @ChequeBank,                  
 @ChequeBranch = @ChequeBranch,                  
 @ChequeNumber = @ChequeNumber,                  
 @ChequeDate =  @ChequeDate,                  
 @ChequeStatus =  @ChequeStatus,              
 @Description = @Description ,            
 @MandirVoucherId = null   ,    
 @BhandarTransactionId = @Id    
    
END    
    
 --Update B set B.Balance=SP.Balance         
 --from Bhandar as B         
 --Join SP on SP.BhandarId=B.Id        
            
            
 --IF( isnull(@PurchasingPrice,0)>0 )            
 --BEGIN            
             
 --declare @SupplierAccountId int ;            
 --select @SupplierAccountId = Id from AccountHead where SupplierId= @SupplierId            
 --Declare @CreatedDate Datetime = getdate();            
 --EXEC MultipleAccountTransaction @SupplierAccountId,@PaymentAccountHeadId,@PurchasingPrice,@CreatedDate,@CreatedBy            
             
 --END        
        
 select @Id as Id        
            
 COMMIT TRANSACTION             
  END TRY            
  BEGIN CATCH            
      IF @@TRANCOUNT > 0            
      BEGIN            
          ROLLBACK TRANSACTION -- rollback to MySavePoint            
    select            
        error_message() as errormessage,            
        error_number() as erronumber,            
        error_state() as errorstate,            
        error_procedure() as errorprocedure,            
        error_line() as errorline;            
      END            
  END CATCH            
            
END 