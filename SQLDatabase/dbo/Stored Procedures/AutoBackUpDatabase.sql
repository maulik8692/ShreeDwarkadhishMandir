CREATE Procedure AutoBackUpDatabase  
 As  
BEGIN  
 Declare @Today varchar(250) = Format(Getdate(),'ddMMMyyyy');  
 select @Today = 'D:\Mandir\Backup\Database\KrishnadasAdhikari_'+@Today+'.BAK'  
   
 BACKUP DATABASE KrishnadasAdhikari   
 TO DISK = @Today  
 WITH DESCRIPTION = 'Full backup for KrishnadasAdhikari'  
  
END  