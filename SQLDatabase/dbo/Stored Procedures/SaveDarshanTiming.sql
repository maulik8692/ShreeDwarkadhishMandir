-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,12-OCt-2018>
-- Description:	<Description,,SaveDarshanTiming>
-- =============================================
CREATE PROCEDURE SaveDarshanTiming
			@DarshanId int
           ,@DarshanDate datetime
           ,@StartTime datetime
           ,@EndTime datetime
           ,@Note varchar(500) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
   
	INSERT INTO dbo.DarshanTiming
           (DarshanId
           ,DarshanDate
           ,StartTime
           ,EndTime
           ,Note)
     VALUES
           (
			@DarshanId
           ,@DarshanDate
           ,@StartTime
           ,@EndTime
           ,isnull(@Note,''))

END
