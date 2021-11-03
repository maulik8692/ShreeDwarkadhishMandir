-- =============================================          
-- Author:  <Author,,Maulik Shah>          
-- Create date: <Create Date,,19 Aug 2018>          
-- Description: <Description,,SaveAccountTransaction>          
-- =============================================          
CREATE PROCEDURE [dbo].[SaveAccountTransaction]          
 @Id int,          
 @AccountId int ,          
 @Debit decimal(18,4) ,          
 @Credit decimal(18,4) ,          
 @ActullyDate DateTime,          
 @MemberId int = null,          
 @CreatedBy int,          
 @IsOpenningBalance bit = 0,          
 @ManorathReceiptId int = null,          
 @ManorathId int = null,          
 @VoucherId int =  null,          
 @PaymentId int = null,          
 @TrasactionType varchar(10) =  null,          
 @ChequeBank varchar(50) = null,          
 @ChequeBranch varchar(50) = null,          
 @ChequeNumber varchar(50) = null,          
 @ChequeDate date =  null,          
 @ChequeStatus int =  null,          
 @ReferenceAccountTransaction int = null,        
 @Description Nvarchar(500)  = null  ,      
 @MandirVoucherId int = null,
 @BhandarTransactionId int = null  
AS          
BEGIN          
BEGIN TRANSACTION;          
  BEGIN TRY          
          
 IF( @Id =0 )          
 BEGIN          
  DECLARE @IdentityValue AS TABLE(ID INT);            
    
  INSERT INTO dbo.AccountTransaction          
           ( AccountId ,Debit ,Credit ,ActullyDate ,IsOpenningBalance ,MemberId ,ManorathId ,VoucherId ,PaymentId          
   ,ManorathReceiptId ,ChequeBank ,ChequeBranch ,ChequeNumber ,ChequeDate ,ChequeStatus ,ReferenceAccountTransaction ,CreatedBy,Description,MandirVoucherId,
   BhandarTransactionId)          
      OUTPUT Inserted.ID INTO @IdentityValue           
     VALUES          
           (@AccountId ,@Debit ,@Credit ,@ActullyDate ,@IsOpenningBalance ,@MemberId ,@ManorathId ,@VoucherId ,@PaymentId          
   ,@ManorathReceiptId ,@ChequeBank ,@ChequeBranch ,@ChequeNumber ,@ChequeDate ,@ChequeStatus ,@ReferenceAccountTransaction ,@CreatedBy,@Description,@MandirVoucherId
   ,@BhandarTransactionId)          
            
  select ID as  InsertedId FROM @IdentityValue            
 END          
 ELSE          
 BEGIN          
  UPDATE dbo.AccountTransaction          
  SET           
    AccountId=@AccountId          
    ,Debit=@Debit          
    ,Credit=@Credit          
    ,ActullyDate=@ActullyDate          
    ,IsOpenningBalance=@IsOpenningBalance          
    ,MemberId=@MemberId          
    ,ManorathId=@ManorathId          
    ,VoucherId=@VoucherId          
    ,PaymentId=@PaymentId          
    ,ManorathReceiptId=@ManorathReceiptId          
    ,ChequeBank=@ChequeBank          
    ,ChequeBranch=@ChequeBranch          
    ,ChequeNumber=@ChequeNumber          
    ,ChequeDate=@ChequeDate          
    ,ChequeStatus=@ChequeStatus          
    ,ReferenceAccountTransaction=@ReferenceAccountTransaction          
    ,UpdatedBy =@CreatedBy          
    ,UpdatedOn = GETDATE()        
 ,Description = @Description        
  WHERE Id=@Id          
  select @Id as InsertedId          
 END          
          
 ;WITH SP           
 AS            
 ( select           
  AT.AccountId,SUm(AT.Credit - AT.Debit) as Balance          
  from AccountTransaction as AT          
  where AT.IsDeleted=0          
  and AT.AccountId=@AccountId          
  group by  AT.AccountId          
 )          
 Update AH          
 Set AH.BalanceAmount = Balance          
 from AccountHead as AH           
 inner join SP on SP.AccountId=AH.Id          
          
          
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
   print ERROR_MESSAGE()          
  END CATCH          
          
END 