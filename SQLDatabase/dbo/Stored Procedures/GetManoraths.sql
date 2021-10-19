-- =============================================  
-- Author:  <Author,,Maulik Shah>  
-- Create date: <Create Date,,04-mar-2019>  
-- Description: <Description,,GetManoraths>  
-- GetManoraths 1,100  
-- =============================================  
CREATE PROCEDURE [dbo].[GetManoraths]  
@PageNumber INT ,  
@PageSize   INT   
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 WITH SP   
 AS    
 (    
  SELECT    
   Count(M.Id) over () AS total,  
   @PageNumber as page,  
   @PageSize as records,  
   M.Id,  
   M.ManorathName,M.Nyochhawar, ISNULL(M.CashAccountId,0) as CashAccountId,  
    --ISNULL(CA.AccountName,'') as CashAccountName ,   
   ISNULL(M.ChequeAccountId,0) as ChequeAccountId,   
   --ISNULL(ChA.AccountName,'') ChequeAccountName ,  
   M.IsActive,M.ManorathType  
  FROM Manorath  as M with (nolock)  
    
  ORDER BY M.IsActive , ManorathName  
  OFFSET @PageSize * (@PageNumber - 1) ROWS  
  FETCH NEXT @PageSize ROWS ONLY  
 )SELECT  
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,  
  @PageSize as records, total, Id ,  
  ManorathName,Nyochhawar,CashAccountId,ChequeAccountId,IsActive,ManorathType ,  
  case ManorathType when 1 then 'Regular Bhet'  
  when 2 then 'Darshan'  
  when 3 then 'Manorath Bhet'  
  when 4 then 'Kayami Manorath'  
  else '' end ManorathTypeName  
  
 FROM SP  
END  