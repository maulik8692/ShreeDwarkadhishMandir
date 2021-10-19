-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,05-Dec-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SaveCommunication]
	@EmailContent nvarchar(max),
	@EmailSubject varchar(50),
	@CreatedBy int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into EmailLog (
	EmailId
	,Status
	,Type
	,DateTimeToSend
	,VaishnavId
	,CreatedBy
	,EmailContent
	,EmailSubject
	)
	select V.Email,'Pending','Communication',GETDATE(),V.Id,@CreatedBy,@EmailContent,@EmailSubject from Vaishnav as v
	inner join Mandir as M on M.CityId = V.CityId
	where V.Email is not null and V.Email <> ''

END
