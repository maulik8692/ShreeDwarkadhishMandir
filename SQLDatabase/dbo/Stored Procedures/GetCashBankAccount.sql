-- =============================================  
-- Author:  Maulik Shah  
-- Create date: 19-Oct-2021  
-- Description: GetCashBankAccount  
-- =============================================  
CREATE   PROCEDURE [dbo].[GetCashBankAccount]  
  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
 select   
  AH.Id,  
  AH.AccountName as DisplayText,  
  AH.IsActive,  
  isnull(AH.IsBankAccount,0) as OtherFlag,
  cast(ABS(isnull(AH.BalanceAmount,0)) as varchar(50)) as OtherText
 From AccountHead as AH  
 where   
 AH.IsDeleted=0   
 and   
 (AH.IsCashOnHand=1 or AH.IsBankAccount=1)  
END
