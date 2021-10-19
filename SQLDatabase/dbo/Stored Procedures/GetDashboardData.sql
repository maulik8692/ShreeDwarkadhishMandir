-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,01-Nov-2018>
-- Description:	<Description,,>
-- GetDashboardData 1
-- =============================================
CREATE PROCEDURE [dbo].[GetDashboardData]
	@MandirId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare
	@Vaishnav int ,
	@Manorath int,
	@Bhet decimal(18,2),
	@Balance decimal(18,2);
	
	select @Vaishnav= Count(1) from Vaishnav where IsActive = 1

	select @Bhet= SUM(M.Nek)  from ManorathReceipt as M where cast(M.CreatedOn as date) = CAST(GETDATE() as date)

	select @Manorath= COUNT(1)  from ManorathReceipt as MR 
	inner join Manorath as M on MR.ManorathId = M.Id and M.ManorathType in (2,3)
	--Inner join AccountHead as A on A.Id= M.ManorathAccountId and A.MandirId=@MandirId
	where cast(MR.ManorathDate as date) = CAST(GETDATE() as date) --and A.AccountTypeId in (4,5)

	--select @Balance= SUM(AT.Credit)-SUm(AT.debit) 
	--from AccountTransaction as AT
	--inner join AccountHead as AH on AH.Id=AT.AccountId 
	--where AT.IsDeleted=0
	----and AH.AccountTypeId between 1 and 6
	
	select Isnull(@Vaishnav,0) as Vaishnavs,
		   Isnull(@Manorath,0) as Manorath,
		   Isnull(@Bhet,0) as Bhet,
		   Isnull(@Balance,0) as Balance

END
