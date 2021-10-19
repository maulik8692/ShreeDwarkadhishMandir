-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18-oct-2018>
-- Description:	<Description,,GetUnitOfMeasurement>
-- GetUnitOfMeasurement 1,50
-- =============================================
CREATE PROCEDURE [dbo].[GetUnitOfMeasurement]
	@PageNumber INT ,
	@PageSize   INT 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

		WITH UOM 
	AS  
	(  
	    SELECT  
		Count(Id) over () AS total,
		Id ,
		UnitAbbreviation,
		UnitDescription,
		IsActive 
		from UnitOfMeasurement with (nolock)
		ORDER BY UnitAbbreviation
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
	)SELECT
		(total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,
		@PageSize as records,
		total,
		Id ,
		UnitAbbreviation,
		UnitDescription,
		IsActive 
	FROM UOM
END
