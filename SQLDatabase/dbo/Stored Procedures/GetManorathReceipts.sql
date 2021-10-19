-- =============================================            
-- Author:  <Author,,Maulik Shah>            
-- Create date: <Create Date,,04-Nov-2018>            
-- Description: <Description,,GetManorathReceipts>            
-- GetManorathReceipts 1,1,200            
-- =============================================            
CREATE PROCEDURE [dbo].[GetManorathReceipts]            
 @MandirId int,            
 @PageNumber INT ,            
 @PageSize   INT             
AS            
BEGIN            
 -- SET NOCOUNT ON added to prevent extra result sets from            
 -- interfering with SELECT statements.            
 SET NOCOUNT ON;            
              
 WITH SP             
 AS              
 (             
 select             
   Count(MR.Id) over () AS total,            
   @PageNumber as page            
  ,@PageSize as records            
  ,MR.Id             
  ,case when ISNUMERIC(MR.Description)=1 then MR.Description else MR.ReceiptNo end ReceiptNo
  ,M.ManorathType            
  ,MR.Nek            
  --,MR.VaishnavId            
  ,M.ManorathName            
  ,isnull(MR.ManorathiName,'Vaishnav') as ManorathiName            
  --,MR.Email            
  --,MR.MobileNo            
  ,format(MR.ManorathDate,'MM/dd/yyyy hh:mm:ss tt') as ManorathDate      
  ,MR.CreatedBy            
  ,U.DisplayName            
  from ManorathReceipt as MR            
  Inner join Manorath as M on M.Id= MR.ManorathId            
  inner join ApplicationUser as U on U.Id=MR.CreatedBy            
 -- where  MR.ManorathDate >= CAST(GETDATE() as date)            
  --ORDER BY MR.ManorathDate desc            
  ORDER BY MR.CreatedOn desc,MR.ReceiptNo desc            
  OFFSET @PageSize * (@PageNumber - 1) ROWS            
  FETCH NEXT @PageSize ROWS ONLY            
  )SELECT            
  (total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,            
  @PageSize as records, total, Id , ReceiptNo, ManorathType, Nek,ManorathName,            
  ManorathiName, ManorathDate , CreatedBy,            
  DisplayName            
 FROM SP            
END 