-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,16 Nov 2018>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[GetAccountHeadById]  
 @Id int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 SELECT  A.Id, A.MandirId, A.GroupId, A.AccountName, A.Alias, A.BalanceAmount, A.DebitCredit, A.AccountHolderName  
 ,A.BankName, A.BankAddress, A.AccountNumber, A.IFSCCode, A.BankBranch, A.DateOfIssue, A.DateOfMaturity  
 ,A.InterestRate, A.MaturityAmount, A.IsEditable, A.IsActive, A.AnnexureOrder, A.AnnexureName  
 from AccountHead as A  
 where A.Id=@Id And A.IsDeleted=0   
  
END  