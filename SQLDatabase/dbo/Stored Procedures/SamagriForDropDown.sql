-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,17-Nov-2018>
-- Description:	<Description,, SamagriForDropDown>
-- =============================================
CREATE PROCEDURE SamagriForDropDown
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select S.Id
	,S.Name
	,S.Balance
	,U.UnitAbbreviation
	,U.UnitDescription 
	from SamagriMaster as S
	inner join UnitOfMeasurement as U on U.Id = S.UnitId
END
