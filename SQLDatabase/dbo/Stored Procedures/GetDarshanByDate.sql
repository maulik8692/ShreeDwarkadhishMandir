-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,03-Oct-2018>
-- Description:	<Description,,>
-- GetDarshanByDate '13-oct-2018'
-- =============================================
CREATE PROCEDURE [dbo].[GetDarshanByDate] 
	@Date datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
	IF( @Date is null  )
		BEGIN
		
			Select 
			0 as Id, DM.Id as DarshanId,
			DM.Darshan as DarshanName, 
			(Select CAST(Max(ISNULL(DATEADD(dd,1,DT.DarshanDate),GETDATE())) as date) from DarshanTiming as DT with (nolock)) as FromDarshanDate,
			null as ToDarshanDate,null as FromTime,null as ToTime,
			'' as AdditionalNote
			from dbo.DarshanMaster as DM where Dm.IsActive=1
		
		END
	ELSE
		BEGIN
				
			Select DT.Id,DM.Id as DarshanId,
			DM.Darshan as DarshanName, DT.DarshanDate as FromDarshanDate,
			DT.DarshanDate as ToDarshanDate,
			DT.StartTime as FromTime,DT.EndTime as ToTime,
			DT.Note as AdditionalNote
			from 
			DarshanTiming as DT 
			Inner join dbo.DarshanMaster as DM  on DM.Id=DT.DarshanId and DM.IsActive=1
			where CAST(DT.DarshanDate as date) = CAST(@Date as date)
			
		END
END
