-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,03-Nov-2018>
-- Description:	<Description,,AccountHeadForConfiguration>
-- AccountHeadForConfiguration 1
-- =============================================
CREATE PROCEDURE [dbo].[ManorathConfiguration]
	@MandirId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Id,ManorathName,Nyochhawar from Manorath as M with (nolock) where M.IsDeleted = 0 and M.IsActive = 1
END
