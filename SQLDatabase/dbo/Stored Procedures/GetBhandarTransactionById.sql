-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,22-Aug-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetBhandarTransactionById
	@BhandarId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   SELECT BM.Id as BhandarId, BM.Name as BhandarName, BM.IsActive as IsActive
	FROM BhandarMaster as BM 
	where BM.Id=@BhandarId
END
