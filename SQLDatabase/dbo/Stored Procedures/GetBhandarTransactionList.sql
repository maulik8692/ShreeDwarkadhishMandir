-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,22-Aug-2018>
-- Description:	<Description,,>
-- GetBhandarTransactionList N'ઘઉં'
-- =============================================
CREATE PROCEDURE GetBhandarTransactionList
	@BhandarName nvarchar(400) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT BM.Id as BhandarId, BM.Name as BhandarName, SUM(BT.Credit)-SUM(BT.Debit) as BhandarBalance
	FROM BhandarMaster as BM 
	INNER JOIN BhandarTransaction BT on BT.BhandarId=BM.Id
	WHERE BM.IsActive=1 and BT.IsDeleted=0
	and ((ISNULL(@BhandarName,'')<>'' and BM.Name=ISNULL(@BhandarName,'')) or ISNULL(@BhandarName,'')='')
	Group BY BM.Id, BM.Name
END
