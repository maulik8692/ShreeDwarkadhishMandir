-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,14-Nov-2018>
-- Description:	<Description,,GetAccountTransactions>
-- GetAccountTransactions 1,100
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountTransactions]
@PageNumber INT ,
@PageSize   INT ,
@MandirId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	WITH SP 
	AS  
	(  
		SELECT  
			Count(AT.Id) over () AS total,
			@PageNumber as page,
			@PageSize as records,
			 AT.AccountId
			,AT.ActullyDate
			,AH.AccountName
			,AT.Debit
			,AT.Credit
			,AU.DisplayName
			from AccountTransaction as AT
			inner join AccountHead as AH on AH.Id=AT.AccountId and AH.MandirId=@MandirId
			Inner Join ApplicationUser AS AU on AU.Id=AT.CreatedBy
			where AT.IsDeleted=0
			Order By AT.ActullyDate
		OFFSET @PageSize * (@PageNumber - 1) ROWS
		FETCH NEXT @PageSize ROWS ONLY
	)SELECT
		(total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,
		@PageSize as records, total, AccountId ,
		ActullyDate, ActullyDate, AccountName,
		Debit, Credit, DisplayName
	FROM SP
END
