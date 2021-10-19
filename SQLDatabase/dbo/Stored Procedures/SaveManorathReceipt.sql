-- =============================================              
-- Author:  <Author,,Maulik Shah>              
-- Create date: <Create Date,,04-Nov-2018>              
-- Description: <Description,,SaveManorathReceipt>              
-- =============================================              
CREATE PROCEDURE [dbo].[SaveManorathReceipt]              
 @Nek decimal(18,4) ,@ManorathId int, @ManorathType int, @TrasactionType varchar(10), @VaishnavId int = null,              
 @ManorathiName varchar(50) = null , @Email varchar(50)=null,              
 @MobileNo varchar(50) = null, @ManorathDate datetime, @CreatedBy int,              
 @ChequeBank varchar(50)=null, @ChequeBranch varchar(50)=null, @ChequeNumber varchar(50)=null, @ChequeDate datetime =  null,              
 @ChequeStatus int=null , @ManorathTithiMaas Nvarchar(1500) = null, @ManorathTithiPaksh Nvarchar(1500) = null,          
 @ManorathTithi Nvarchar(1500) = null,@Description varchar(500)      
AS              
BEGIN              
 -- SET NOCOUNT ON added to prevent extra result sets from              
 -- interfering with SELECT statements.              
 SET NOCOUNT ON;              
              
  SET NOCOUNT ON;              
 BEGIN TRANSACTION;              
  BEGIN TRY              
  declare @ReceiptNo int, @InsertedId int, @DateTimeToSend datetime = getdate(),              
  @ReceiptType int = 3,              
  @PaymentId int, @CashAccountId int, @ChequeAccountId int, @VaishnavAccountId int;              
              
  create table #OutputTable (ID INT)              
              
  select               
  @CashAccountId = case when CashAccountId = 0 then null else CashAccountId end,              
  @ChequeAccountId=case when ChequeAccountId =0 then null else ChequeAccountId  end,              
  @VaishnavAccountId=case when VaishnavAccountId   =0 then null else VaishnavAccountId    end            
  from Manorath as M with (nolock) where M.Id=@ManorathId              
            
  IF not exists ( select Id from ReceiptNoCounter )              
  BEGIN              
                
   insert into ReceiptNoCounter              
   ( BhetReceiptNo              
   ,ManorathReceiptNo              
   ,DarshanReceiptNo)              
   values(0,0,0)              
                
  END              
              
  select @ReceiptNo= (case @ReceiptType when 3 then BhetReceiptNo              
  when 4 then ManorathReceiptNo              
  when 5 then DarshanReceiptNo              
  else 0 end) + 1              
  from ReceiptNoCounter              
                
  select @PaymentId=id from Payment where PaymentName=@TrasactionType              
              
  insert into ManorathReceipt              
  (ReceiptNo ,Nek ,ManorathId ,PaymentId ,CashAccountId ,ChequeAccountId ,VaishnavId ,ManorathiName ,Email              
           ,MobileNo ,ManorathDate ,CreatedBy ,ChequeBank ,ChequeBranch ,ChequeNumber ,ChequeDate ,ChequeStatus ,Description             
  ) OUTPUT INSERTED.ID INTO #OutputTable(ID)              
  values(              
  @ReceiptNo ,@Nek ,@ManorathId ,@PaymentId ,@CashAccountId ,@ChequeAccountId ,@VaishnavId ,@ManorathiName ,@Email              
           ,@MobileNo ,@ManorathDate ,@CreatedBy ,@ChequeBank ,@ChequeBranch ,@ChequeNumber ,@ChequeDate ,@ChequeStatus,@Description              
  )              
              
  select @InsertedId  = Id from #OutputTable              
            
          
 IF( @ManorathType = 4 )          
 BEGIN          
          
 insert into KayamiSalabadiDetail (VaishnavId,ManorathTithiMaas,ManorathTithiPaksh,ManorathTithi,StartDate,EndDate,CreatedBy,ManorathReceiptId)          
 select @VaishnavId,@ManorathTithiMaas,@ManorathTithiPaksh,@ManorathTithi,GETDATE(),DATEADD(YY,CONVERT(int,KeyValue),GETDATE()),@CreatedBy,@InsertedId           
 from AppConfiguration where KeyName='KayamiManorathYear'          
          
 END          
          
              
  IF( @TrasactionType = 'Cash')              
  BEGIN              
    print 'Cash'            
            
 EXEC MultipleAccountTransaction @VaishnavAccountId,@CashAccountId,@Nek,@ManorathDate,@VaishnavId,@CreatedBy,              
   @InsertedId,@ManorathId,1,@PaymentId,@TrasactionType,null,null,null,null,null,@Description,null              
                
  END              
  else               
  BEGIN              
                
   EXEC MultipleAccountTransaction  
     @VaishnavAccountId,@ChequeAccountId,@Nek,@ManorathDate,@VaishnavId  ,            
   @CreatedBy,@InsertedId, @ManorathId,1,@PaymentId,@TrasactionType,@ChequeBank,@ChequeBranch,@ChequeNumber,              
   @ChequeDate,@ChequeStatus,@Description,null               
          
  END              
                
  IF( Isnull(@Email,'')<>'' )              
  BEGIN              
                
    exec SaveEmailLog @Id = 0,              
         @EmailId = @Email,              
         @Status = 'Pending',              
         @Type = 'Receipt',              
         @DateTimeToSend = @DateTimeToSend ,              
         @VaishnavId = @VaishnavId ,@ReceiptId=@InsertedId,@PadhramaniId=null,@PadhramaniStatus=null              
                
  END              
               
  IF( @ReceiptType = 3 )              
  BEGIN              
   update ReceiptNoCounter set BhetReceiptNo= @ReceiptNo;              
  END              
  else IF( @ReceiptType = 4 )              
  BEGIN              
   update ReceiptNoCounter set ManorathReceiptNo= @ReceiptNo;              
  END              
  else IF( @ReceiptType = 5 )              
  BEGIN              
   update ReceiptNoCounter set DarshanReceiptNo= @ReceiptNo;              
  END              
              
  select @InsertedId as Id, (case @ReceiptType when 3 then 'BhetReceipt'              
  when 4 then 'ManorathReceipt'              
  when 5 then 'DarshanReceipt'              
  else '' end) as ManorathType              
              
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