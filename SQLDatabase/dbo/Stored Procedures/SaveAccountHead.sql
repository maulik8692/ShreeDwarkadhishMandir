  
-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,19 Jun 2018>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[SaveAccountHead]  
@Id int  
,@MandirId int  
,@GroupId int  
,@AccountName varchar(50)  
,@Alias varchar(50)  
,@BalanceAmount decimal(18,2) = null  
,@DebitCredit varchar(50) = 'Debit'  
,@AccountHolderName varchar(50) = Null  
,@BankName varchar(50) = null  
,@BankAddress varchar(500) = null  
,@AccountNumber varchar(50) = null  
,@IFSCCode varchar(50) = null  
,@BankBranch varchar(50) = null  
,@DateOfIssue datetime = null  
,@DateOfMaturity datetime = null  
,@InterestRate decimal(18,2)  
,@MaturityAmount decimal(18,2)  
,@IsEditable bit  
,@IsActive bit  
,@CreatedBy int ,
@AnnexureOrder int = 0,
@AnnexureName varchar(50)=null
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
  Create table #AccountTransactionId (ID INT);    
    
  
 Declare @AccountHeadId int,@BalanceDate datetime=Getdate()  
  
IF( @Id=0 )  
BEGIN  
 Create TABLE #IdentityValue (ID INT);    
   
 INSERT INTO dbo.AccountHead  
 (MandirId ,GroupId ,AccountName ,Alias ,BalanceAmount ,DebitCredit ,AccountHolderName  
 ,BankName ,BankAddress ,AccountNumber ,IFSCCode ,BankBranch ,DateOfIssue ,DateOfMaturity  
 ,InterestRate ,MaturityAmount ,IsEditable ,IsActive ,CreatedBy,AnnexureOrder,AnnexureName  )  
 OUTPUT Inserted.ID INTO #IdentityValue   
 VALUES ( @MandirId ,@GroupId ,@AccountName ,@Alias ,@BalanceAmount ,@DebitCredit ,@AccountHolderName  
 ,@BankName ,@BankAddress ,@AccountNumber ,@IFSCCode ,@BankBranch ,@DateOfIssue ,@DateOfMaturity  
 ,@InterestRate ,@MaturityAmount ,@IsEditable ,@IsActive ,@CreatedBy ,@AnnexureOrder,@AnnexureName  )  
   
 IF( @BalanceAmount > 0 )  
 BEGIN  
    
  select @AccountHeadId = ID from #IdentityValue  
    
  IF( @DebitCredit='Credit' )  
  BEGIN  
   insert into #AccountTransactionId  
   EXEC SaveAccountTransaction 0,@AccountHeadId,0,@BalanceAmount,@BalanceDate,0,@CreatedBy,1  
  END  
  ELSE   
  BEGIN  
   insert into #AccountTransactionId  
   EXEC SaveAccountTransaction 0,@AccountHeadId,@BalanceAmount,0,@BalanceDate,0,@CreatedBy,1   
  END  
 END  
  
END  
ELSE  
BEGIN  
  
 UPDATE [dbo].[AccountHead]  
 SET MandirId = @MandirId, GroupId = @GroupId, AccountName = @AccountName, Alias = @Alias, AccountHolderName = @AccountHolderName,  
 BankName = @BankName, BankAddress = @BankAddress, AccountNumber = @AccountNumber,IFSCCode = @IFSCCode,  
 BankBranch = @BankBranch, DateOfIssue = @DateOfIssue, DateOfMaturity= @DateOfMaturity,  
 InterestRate = @InterestRate, MaturityAmount = @MaturityAmount, IsEditable = @IsEditable, IsActive= @IsActive,   
 AnnexureOrder=@AnnexureOrder,AnnexureName = @AnnexureName ,
 UpdateBy = @CreatedBy, UpdateOn = GETDATE()  
 WHERE Id=@Id  
  
 --IF( @BalanceAmount > 0 )  
 --BEGIN  
 -- select @AccountHeadId = ID from #IdentityValue  
    
 -- IF( @DebitCredit='Credit' )  
 -- BEGIN  
 --  insert into #AccountTransactionId  
 --  EXEC SaveAccountTransaction 0,@AccountHeadId,0,@BalanceAmount,@BalanceDate,0,@CreatedBy,1  
 -- END  
 -- ELSE   
 -- BEGIN  
 --  insert into #AccountTransactionId  
 --  EXEC SaveAccountTransaction 0,@AccountHeadId,@BalanceAmount,0,@BalanceDate,0,@CreatedBy,1   
 -- END  
 --END  
  
END  
  
END  