-- =============================================
-- Author:		Maulik Shah
-- Create date: 19-Oct-2021
-- Description:	GetSupplierAccount
-- =============================================
CREATE PROCEDURE GetSupplierAccount 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select 
	S.Id,
	S.SupplierName DisplayText
	from Supplier as S 
	Join AccountHead as AH on AH.SupplierId=S.Id
	and S.IsActive=1
END