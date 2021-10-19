-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,19-Nov-2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetSamagriTransactionById
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	SMT.Debit,
	SMT.Credit
	 
	from 
	SamagriTransaction as SMT with (nolock)
	inner join SamagriMaster SM with (nolock) On SM.Id=SMT.SamagriId
	Inner join SamagriBhandarDetail as SD with (nolock) on SD.SamagriId = SM.Id
	Inner join UnitOfMeasurement as SU with (nolock) on SU.Id=SM.UnitId
	Inner join UnitOfMeasurement as SDU with (nolock) on SDU.Id=SD.UnitId


END
