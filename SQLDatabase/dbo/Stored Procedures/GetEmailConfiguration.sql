-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,14-Oct-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetEmailConfiguration
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Server,Port,Username,Password,DisplayName,SSL,ExchangeService,IsActive
	from EmailConfiguration
	where IsActive = 1
END
