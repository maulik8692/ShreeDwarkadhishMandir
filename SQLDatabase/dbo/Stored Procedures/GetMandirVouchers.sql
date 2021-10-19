-- =============================================      
-- Author:  <Author,,Maulik Shah>      
-- Create date: <Create Date,,18-oct-2018>      
-- Description: <Description,,GetSuppliers>      
-- GetMandirVouchers 1,100      
-- =============================================      
CREATE PROCEDURE [dbo].GetMandirVouchers      
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
   Count(MV.Id) over () AS total,      
   @PageNumber as page,      
   @PageSize as records,      
   MV.Id       
   , A.AccountName    
   ,MV.VoucherNo  
   ,MV.VoucherAmount    
   ,FORMAT(MV.VoucherDate,'dd-MMM-yyyy') as VoucherDate
   ,case VoucherType when 'Borrow' then 'Udhar Voucher' else 'Jama Voucher' end VoucherType
  FROM MandirVoucher  as MV with (nolock)      
  inner join AccountHead as A with (nolock) on A.Id=MV.AccountId     
  ORDER BY MV.VoucherDate desc,VoucherNo desc    
  OFFSET @PageSize * (@PageNumber - 1) ROWS      
  FETCH NEXT @PageSize ROWS ONLY      
 )SELECT      
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,@PageSize as records, total, Id ,        
  AccountName, VoucherAmount, VoucherDate as DisplayVoucherDate ,VoucherNo , VoucherType 
 FROM SP      
      
END 