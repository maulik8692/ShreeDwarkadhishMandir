-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,15-Aug-2018>
-- Description:	<Description,,Get list of user Type>
-- =============================================
CREATE PROCEDURE GetUserType 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id,TypeName from UserType where IsDeleted= 0
END
