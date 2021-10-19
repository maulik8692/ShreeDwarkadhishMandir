-- =============================================        
-- Author:  <Author,,Maulik Shah>        
-- Create date: <Create Date,,18-oct-2018>        
-- Description: <Description,,GetSuppliers>        
-- GetSuppliers 1,100        
-- =============================================        
CREATE PROCEDURE dbo.SaveMandirVoucher        
  @VoucherNo int      
 ,@VoucherDate date      
 ,@AccountId int      
 ,@VoucherAmount decimal(18,5)      
 ,@Description nvarchar(4000)  = null    
 ,@CreatedBy int
 ,@VoucherType varchar(50)
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
        
Create Table #IdentityValue (ID INT);            
insert into MandirVoucher(      
VoucherNo      
,VoucherDate      
,AccountId      
,VoucherAmount      
,Description      
,CreatedBy
,VoucherType)       
OUTPUT Inserted.ID INTO #IdentityValue           
VALUES (      
@VoucherNo      
,@VoucherDate      
,@AccountId      
,@VoucherAmount      
,@Description      
,@CreatedBy
,@VoucherType)      

Declare @CashOnHandId int= cast ((select KeyValue from AppConfiguration where KeyName ='CashOnHandId') as int)
      
declare @CreditAccountId int = case @VoucherType when 'Borrow' then @CashOnHandId else @AccountId end
declare @DebitAccountId int = case @VoucherType when 'Borrow' then @AccountId else @CashOnHandId end

declare @Identity int = (select ID from #IdentityValue)      
      
exec MultipleAccountTransaction       
 @CreditAccountId = @CreditAccountId,            
 @DebitAccountId = @DebitAccountId,            
 @TransactionAmount = @VoucherAmount,            
 @TransactionDate = @VoucherDate,            
 @VaishnavId  = null,             
 @CreatedBy =@CreatedBy,            
 @ManorathReceiptId =  null,            
 @ManorathId = null,            
 @VoucherId  =  null,            
 @PaymentId = null,            
 @TrasactionType  =  null,            
 @ChequeBank  = null,            
 @ChequeBranch = null,            
 @ChequeNumber = null,            
 @ChequeDate =  null,            
 @ChequeStatus =  null,        
 @Description = @Description ,      
 @MandirVoucherId = @Identity      
      
 --select @Identity as MandirVoucherId      
      
END 