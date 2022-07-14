-- =============================================      
-- Author:  <Author,,Maulik Shah>      
-- Create date: <Create Date,,07-Nov-2018>      
-- Description: <Description,,GetManorathReceiptReport>      
-- GetManorathReceiptReport 1,'20-Jul-2019','20-Jul-2019',null,null,0,0,0      
-- =============================================      
CREATE PROCEDURE dbo.GetManorathReceiptReport      
 @MandirId int       
 ,@FromDate datetime=null      
 ,@ToDate datetime=null      
 ,@ManorathFromDate datetime=null      
 ,@ManorathToDate datetime=null      
 ,@AccountId int = 0      
 ,@OnlyManorath bit = 0      
 ,@UserId int=0      
AS      
BEGIN      
      
 select       
  MR.Id       
  ,MR.ReceiptNo      
  ,M.VaishnavAccountId as ManorathAccountId      
  ,A.AccountName      
  ,M.ManorathName      
  ,Case M.ManorathType when 1 then 'Regular Bhet' when 2 then 'Darshan' when 3 then 'Manorath' when 4 then 'Kayami Salabadi' else '' end as ManorathType      
  ,MR.Nek      
  ,MR.VaishnavId      
  ,isnull(MR.ManorathiName,'Vaishnav') as ManorathiName      
  ,isnull(MR.Email,'') as Email      
  ,case isnull(MR.MobileNo,'') when '+91 ' then ''       
  else isnull(MR.MobileNo,'')  end as MobileNo      
  ,FORMAT(MR.ManorathDate,'MM/dd/yyyy hh:mm:ss tt') ManorathDate
  ,MR.CreatedBy      
  ,U.DisplayName      
  from ManorathReceipt as MR      
  inner join Manorath as M on M.Id = MR.ManorathId      
  Inner join AccountHead as A on A.Id= M.VaishnavAccountId and A.MandirId=@MandirId      
  inner join ApplicationUser as U on U.Id=MR.CreatedBy      
  where     
  (@FromDate is null or cast(MR.CreatedOn as date) between cast(@FromDate as date) and cast(@ToDate as date) )      
  and (@ManorathFromDate is null or cast(MR.ManorathDate as date) between cast(@ManorathFromDate as date) and cast(@ManorathToDate as date))      
  and (ISNULL(@AccountId,0)=0 or M.Id=ISNULL(@AccountId,0))      
  AND (ISNULL(@UserId,0)=0 or U.Id=ISNULL(@UserId,0))      
  and (ISNULL(@OnlyManorath,0) =0 or M.ManorathType in (2,3,4))      
  ORDER BY MR.ReceiptNo, MR.ManorathDate --desc      
END 