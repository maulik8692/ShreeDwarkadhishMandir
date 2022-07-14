-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,03-Oct-2018>
-- Description:	<Description,,>
-- GetDarshanByDate '08-Jul-2022'
-- =============================================
CREATE PROCEDURE dbo.GetDarshanByDate 
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
			FORMAT(ISNULL((Select CAST(Max(ISNULL(DATEADD(dd,1,DT.DarshanDate),GETDATE())) as date) from DarshanTiming as DT with (nolock)),GETDATE()),'MM/dd/yyyy hh:mm:ss tt') as FromDarshanDate,
			null as ToDarshanDate,null as FromTime,null as ToTime,
			'' as AdditionalNote
			from dbo.DarshanMaster as DM where Dm.IsActive=1
		
		END
	ELSE
		BEGIN
				
			Select DT.Id,DM.Id as DarshanId,
			DM.Darshan as DarshanName, FORMAT(DT.DarshanDate,'MM/dd/yyyy hh:mm:ss tt') as FromDarshanDate,
			FORMAT(DT.DarshanDate,'MM/dd/yyyy hh:mm:ss tt') as ToDarshanDate,
			FORMAT(DT.StartTime,'MM/dd/yyyy hh:mm:ss tt') as FromTime,
			FORMAT(DT.EndTime,'MM/dd/yyyy hh:mm:ss tt') as ToTime,
			DT.Note as AdditionalNote
			from 
			DarshanTiming as DT 
			Inner join dbo.DarshanMaster as DM  on DM.Id=DT.DarshanId and DM.IsActive=1
			where CAST(DT.DarshanDate as date) = CAST(@Date as date)
			
		END
END
