create procedure AutoBackUp
AS
BEGIN
 
	Declare @CurrentDate varchar(25)= convert(varchar(25),GETDATE(),106)

	Declare @Path nvarchar(max) = N'D:\Learning\Temple\Database\KrishnadasAdhikari_'+@CurrentDate+'.bak'

	BACKUP DATABASE KrishnadasAdhikari
	TO  DISK = @Path
	WITH CHECKSUM;

END
