-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date,,19 Aug 2018>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAccountHeads]
@PageNumber INT ,
@PageSize   INT 
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
			Count(A.Id) over () AS total,
			@PageNumber as page,
			@PageSize as records,
			A.Id, A.AccountName, A.Alias, A.BalanceAmount, A.DebitCredit, A.IsActive, A.IsDefaultRecord IsEditable, AG.GroupName, DG.NatureOfGroup
			from AccountHead as A with (nolock)
			Inner join AccountGroup AG with (nolock) on AG.Id=A.GroupId 
			Inner Join DefaultGroups as DG  with (nolock) on DG.Id=AG.DefaultGroupId
			where A.IsDeleted=0
			ORDER BY AccountName
			OFFSET @PageSize * (@PageNumber - 1) ROWS
			FETCH NEXT @PageSize ROWS ONLY
	)SELECT
		(total/@PageSize) +  (case when total%@PageSize > 0 then 1 else 0 end) as page,
		@PageSize as records, total, Id 
		, AccountName, Alias, ABS(BalanceAmount) as BalanceAmount, DebitCredit, IsActive, IsEditable, GroupName, NatureOfGroup
		FROM SP

END
