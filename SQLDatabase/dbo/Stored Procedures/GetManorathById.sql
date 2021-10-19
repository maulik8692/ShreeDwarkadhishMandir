-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,Maulik Shah>
-- =============================================
CREATE PROCEDURE [dbo].[GetManorathById]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT M.Id, M.ManorathName,M.Nyochhawar, 
	ISNULL(M.CashAccountId,0) as CashAccountId, 
	ISNULL(M.ChequeAccountId,0) as ChequeAccountId, 
	ISNULL(M.VaishnavAccountId,0) as VaishnavAccountId, 
	M.IsActive,M.ManorathType,M.DarshanId
	FROM Manorath  as M with (nolock)
	LEFT JOIN AccountHead as CA on CA.Id=M.CashAccountId
	LEFT JOIN AccountHead as ChA on ChA.Id=M.ChequeAccountId
	where M.Id = @Id
END
