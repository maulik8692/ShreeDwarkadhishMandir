-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,05-Sep-2018>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].GetOccupation
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		SELECT O.Id,O.Professions from Occupation as O order By O.Professions 

END
