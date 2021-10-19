-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,18-oct-2018>
-- Description:	<Description,,GetSuppliers>
-- GetSuppliersForDropdown 1,100
-- =============================================
Create PROCEDURE [dbo].[GetSuppliersForDropdown]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT S.Id ,
		S.SupplierId
		,S.SupplierName
		FROM Supplier  as S with (nolock)
		where S.IsActive=1
		ORDER BY SupplierName
END
