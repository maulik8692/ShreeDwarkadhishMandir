-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18 AUg 2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAppConfiguration]
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,KeyName,KeyValue,KeyDisplayName from AppConfiguration where IsDeleted = 0 
END
