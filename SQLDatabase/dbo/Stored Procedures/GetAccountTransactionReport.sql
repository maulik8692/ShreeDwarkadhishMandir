
-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,14-Nov-2018>
-- Description:	<Description,,GetAccountTransactionReport>
-- GetAccountTransactionReport 1,1
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountTransactionReport]
	@MandirId int = 0,
	@AccountId int = null,
	@FromDate datetime = null,
	@ToDate datetime = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select
	AT.Id, 
	 AT.AccountId
	,AT.ActullyDate as TransactionDate
	,AH.AccountName
	,AT.Debit
	,AT.Credit
	,AU.DisplayName
	from AccountTransaction as AT
	inner join AccountHead as AH on AH.Id=AT.AccountId and AH.MandirId=@MandirId
	Inner Join ApplicationUser AS AU on AU.Id=AT.CreatedBy
	where AT.IsDeleted=0
	and (@FromDate is null or CAST(AT.ActullyDate as date) between @FromDate and @ToDate) 
	and (ISNULL(@AccountId,0) =0 or AT.AccountId= isnull(@AccountId,0))
	Order By AT.ActullyDate desc

END