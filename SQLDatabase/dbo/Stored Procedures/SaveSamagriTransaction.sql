-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,21-Aug-2018>
-- Description:	<Description,,SaveBhandarTransaction>
-- =============================================
CREATE PROCEDURE dbo.SaveSamagriTransaction
@SamagriId int
,@Credit decimal(18,5)
,@Debit decimal(18,5)
,@CreatedBy int
,@TransactionId int = null
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRANSACTION;
	 BEGIN TRY 
	DECLARE @IdentityValue AS TABLE(ID INT);  

	INSERT INTO dbo.SamagriTransaction (SamagriId ,Debit ,Credit ,TransactionId,CreatedBy )
	   OUTPUT Inserted.ID INTO @IdentityValue 
    VALUES (@SamagriId,@Debit,@Credit,@TransactionId,@CreatedBy )

	;WITH SP 
	AS  
	(  
		SELECT  
			SUm (SMT.Credit -SMT.Debit)as Balance
			from SamagriMaster as S 
			inner join SamagriTransaction as SMT on SMT.SamagriId=S.Id
			where S.Id = @SamagriId
			and SMT.IsDelete=0
			group by S.Id
	)
	Update SamagriMaster set Balance = (Select SP.Balance from SP) where Id = @SamagriId

	select ID as  InsertedId FROM @IdentityValue  

 COMMIT TRANSACTION 
	 END TRY
	 BEGIN CATCH
	     IF @@TRANCOUNT > 0
	     BEGIN
	         ROLLBACK TRANSACTION -- rollback to MySavePoint
			 select
        error_message() as errormessage,
        error_number() as erronumber,
        error_state() as errorstate,
        error_procedure() as errorprocedure,
        error_line() as errorline;
	     END
	 END CATCH

END
