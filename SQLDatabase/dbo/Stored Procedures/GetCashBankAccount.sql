-- =============================================
-- Author:		Maulik Shah
-- Create date: 19-Oct-2021
-- Description:	GetCashBankAccount
-- =============================================
CREATE   PROCEDURE GetCashBankAccount

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select 
		AH.Id,
		AH.AccountName as DisplayText,
		AH.IsActive,
		AH.IsBankAccount as OtherFlag
	From AccountHead as AH
	where 
	AH.IsDeleted=0 
	and 
	(AH.IsCashOnHand=1 or AH.IsBankAccount=1)
END
