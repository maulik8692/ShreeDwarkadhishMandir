-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,06-sep-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetVillagesByCityId
	@CityId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select Id,Village+' - '+PostalCode as Village,PostalCode,CityId from Villages where CityId=@CityId order by Village
END
