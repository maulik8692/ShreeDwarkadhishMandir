-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,14-oct-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SaveServiceStatus
	@ServiceName Varchar(50),
	@IsRunning bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update ServiceStatus set IsRunning=@IsRunning where ServiceName=@ServiceName and IsActive=1

	INSERT INTO [dbo].[ServiceLog]
           ([ServiceId]
           ,[RunDateTime]
           ,[Staus])
     VALUES
           ((select Id from ServiceStatus where ServiceName=@ServiceName and IsActive=1)
           ,GETDATE()
           ,@IsRunning)


END
