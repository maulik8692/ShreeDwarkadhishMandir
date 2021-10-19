-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,12-oct-2018>
-- Description:	<Description,,GetLastDarshanDate>
-- =============================================
CREATE PROCEDURE [dbo].[GetLastDarshanDate]
			
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
   
	Select CAST(Max(ISNULL(DT.DarshanDate,GETDATE())) as date) as LastDarshanDate from DarshanTiming as DT with (nolock)

END
