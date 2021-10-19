-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18-oct-2018>
-- Description:	<Description,,GetUnitOfMeasurementById>
-- =============================================
CREATE PROCEDURE dbo.GetUnitOfMeasurementById
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select  Id ,
	UnitAbbreviation,
	UnitDescription,
	IsActive from UnitOfMeasurement
	where id= @id

END
