-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,14-Oct-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveEmailConfiguration] 
	-- Add the parameters for the stored procedure here
	@Server varchar(50)
   ,@Port int
   ,@Username varchar(50)
   ,@Password varchar(50)
   ,@DisplayName varchar(50)
   ,@SSL bit
   ,@ExchangeService bit
   ,@IsActive bit
   ,@CreatedBy int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	if EXISTS (select 1 from EmailConfiguration)
	BEGIN
	
	UPDATE dbo.EmailConfiguration
			SET Server = @Server
			   ,Port = @Port
			   ,Username = @Username
			   ,Password = @Password
			   ,DisplayName = @DisplayName
			   ,SSL = @SSL
			   ,ExchangeService = @ExchangeService
			   ,IsActive = @IsActive 
	
	END
	ELSE
	BEGIN
	
	 insert into EmailConfiguration
	 (Server
		,Port
		,Username
		,Password
		,DisplayName
		,SSL
		,ExchangeService
		,IsActive
	 ) values
	 (
		 @Server
		,@Port
		,@Username
		,@Password
		,@DisplayName
		,@SSL
		,@ExchangeService
		,@IsActive
	 )
	
	END


END
