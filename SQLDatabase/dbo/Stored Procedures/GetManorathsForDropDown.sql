-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,04-Mar-2019>
-- Description:	<Description,,GetManorathForDropDown>
-- =============================================
CREATE PROCEDURE [dbo].[GetManorathsForDropDown]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT M.Id, M.ManorathName,M.Nyochhawar, 
	ISNULL(M.CashAccountId,0) as CashAccountId,
	ISNULL(M.VaishnavAccountId,0) as VaishnavAccountId,
	ISNULL(M.ChequeAccountId,0) as ChequeAccountId,
	M.IsActive , M.ManorathType
	FROM Manorath  as M with (nolock)
	LEFT JOIN AccountHead as CA on CA.Id=M.CashAccountId
	LEFT JOIN AccountHead as ChA on ChA.Id=M.ChequeAccountId
	ORDER BY ManorathName
END
