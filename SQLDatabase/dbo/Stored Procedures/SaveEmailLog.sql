-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Nov-2018>
-- Description:	<Description,,SaveEmailLog>
-- =============================================
CREATE PROCEDURE [dbo].[SaveEmailLog] 
	@Id int,
	@EmailId varchar(50),
	@Status varchar(50),
	@Type varchar(50),
	@DateTimeToSend datetime,
	@VaishnavId int =  null,
	@ReceiptId int=  null,
	@PadhramaniId int=  null,
	@PadhramaniStatus varchar(50)= null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
IF( @Id = 0 )
BEGIN

INSERT INTO dbo.EmailLog
           (EmailId,Status
           ,Type,DateTimeToSend
           ,VaishnavId,ReceiptId,PadhramaniId,PadhramaniStatus
          )
     VALUES
           (@EmailId,@Status 
           ,@Type,@DateTimeToSend 
           ,@VaishnavId ,@ReceiptId,@PadhramaniId,@PadhramaniStatus
           ) 

END
else

BEGIN

 update dbo.EmailLog set Status=@Status,SentTime=GETDATE() where id = @Id

END



END
