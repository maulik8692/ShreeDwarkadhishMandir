-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,03-Nov-2018>
-- Description:	<Description,,>
-- CheckReceiptConfiguration
-- =============================================
CREATE PROCEDURE [dbo].[CheckReceiptConfiguration]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if (cast( (select KeyValue from AppConfiguration where KeyName='AccountHeadAgainstReceipt' and IsDeleted=0) as int) > 0)
	BEGIN
	
	select cast(1 as bit) as ReceiptConfigurationExists
	
	END
	ELSE
	BEGIN
	select cast(0 as bit) as ReceiptConfigurationExists
	END
END
