-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,21-Oct-2018>
-- Description:	<Description,,AccountHeadForBhet>
-- AccountHeadForBhet 1
-- =============================================
CREATE PROCEDURE [dbo].[AccountHeadForBhet]
	@MandirId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--select A.Id as 
	--AccountId,
	--A.AccountName,
	--A.BalanceAmount,
	--A.Nyochavar,
	--A.AccountTypeId,
	--case A.AccountTypeId when 3 then 'BhetReceipt' when 4 then 'ManorathReceipt'  when 5 then 'DarshanReceipt' else '' end ReceiptType
	--from AccountHead as A
	--where A.IsDeleted=0 
	--and A.MandirId=@MandirId 
	--and A.AccountTypeId in (3,5)
	--order by A.AccountName
END
