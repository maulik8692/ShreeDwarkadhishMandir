-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Dec-2018>
-- Description:	<Description,,GetEmailToSend>
-- =============================================
CREATE PROCEDURE UpdateEmailLog
	@Id int ,
	@Status varchar(50)
AS
BEGIN
	Update EmailLog set Status=@Status where id =@Id
END
