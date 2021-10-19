-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Nov-2018>
-- Description:	<Description,,SaveAppConfiguration>
-- =============================================
Create PROCEDURE dbo.SaveAppConfiguration
	@Id int,
	@KeyValue varchar(500)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update dbo.AppConfiguration set KeyValue=@KeyValue where id = @Id

END
