-- =============================================        
-- Author:  <Author,,Maulik Shah>        
-- Create date: <Create Date,,20-Aug-2018>        
-- Description: <Description,,>        
-- =============================================        
CREATE PROCEDURE [dbo].[MultipleAccountTransaction]        
 @CreditAccountId int,        
 @DebitAccountId int,        
 @TransactionAmount decimal(18,4),        
 @TransactionDate Datetime,        
 @VaishnavId int = null,         
 @CreatedBy int,        
 @ManorathReceiptId int = null,        
 @ManorathId int = null,        
 @VoucherId int =  null,        
 @PaymentId int = null,        
 @TrasactionType varchar(10) =  null,        
 @ChequeBank varchar(50) = null,        
 @ChequeBranch varchar(50) = null,        
 @ChequeNumber varchar(50) = null,        
 @ChequeDate datetime =  null,        
 @ChequeStatus int =  null,    
 @Description Nvarchar(500)  = null  ,  
 @MandirVoucherId int = null    
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
 BEGIN TRANSACTION;        
  BEGIN TRY        
  Create table #AccountTransactionId (ID INT);          
         
  declare @ReferenceAccountTransaction int        
          
  INSERT INTO #AccountTransactionId        
  EXEC dbo.SaveAccountTransaction @Id = 0, @AccountId = @CreditAccountId, @Debit = 0, @Credit = @TransactionAmount,         
  @ActullyDate = @TransactionDate, @MemberId = @VaishnavId, @CreatedBy = @CreatedBy, @IsOpenningBalance = 0,        
  @ManorathReceiptId = @ManorathReceiptId, @ManorathId = @ManorathId, @VoucherId = @VoucherId, @PaymentId = @PaymentId,        
  @TrasactionType = @TrasactionType, @ChequeBank = @ChequeBank , @ChequeBranch = @ChequeBranch , @ChequeNumber = @ChequeNumber ,        
  @ChequeDate = @ChequeDate , @ChequeStatus = @ChequeStatus , @ReferenceAccountTransaction = NULL,@Description  = @Description ,   
  @MandirVoucherId   = @MandirVoucherId  
        
        
  select @ReferenceAccountTransaction = Id from #AccountTransactionId        
        
  INSERT INTO #AccountTransactionId        
  EXEC dbo.SaveAccountTransaction @Id = 0, @AccountId = @DebitAccountId, @Debit = @TransactionAmount,        
  @Credit = 0, @ActullyDate = @TransactionDate, @MemberId = @VaishnavId, @CreatedBy = @CreatedBy,        
  @IsOpenningBalance = 0, @ManorathReceiptId = @ManorathReceiptId, @ManorathId = @ManorathId,        
  @VoucherId = @VoucherId, @PaymentId = @PaymentId, @TrasactionType = @TrasactionType,        
  @ChequeBank = NULL, @ChequeBranch = NULL, @ChequeNumber = NULL, @ChequeDate = NULL,        
  @ChequeStatus = NULL, @ReferenceAccountTransaction = @ReferenceAccountTransaction,@Description  =@Description, @MandirVoucherId  = null    
        
  COMMIT TRANSACTION         
  END TRY        
  BEGIN CATCH    
  
  print 'catch'            
   print @@TRANCOUNT            
   print ERROR_NUMBER()            
   print ERROR_SEVERITY()            
   print ERROR_STATE()             
   print ERROR_PROCEDURE()             
   print ERROR_LINE()             
   print ERROR_MESSAGE()           
      IF @@TRANCOUNT > 0        
      BEGIN        
          ROLLBACK TRANSACTION -- rollback to MySavePoint        
      END        
  END CATCH        
           
        
END 