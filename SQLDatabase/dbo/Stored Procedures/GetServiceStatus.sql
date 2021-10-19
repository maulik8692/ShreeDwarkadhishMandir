-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,14-oct-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetServiceStatus
	@ServiceName Varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ServiceName,IsRunning,TimeInterval,IsActive from ServiceStatus where ServiceName=@ServiceName and IsActive=1
END
