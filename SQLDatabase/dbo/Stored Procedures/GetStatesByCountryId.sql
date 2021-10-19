CREATE PROCEDURE [dbo].[GetStatesByCountryId]
@CountryId Int = 101
AS
BEGIN

SELECT Id,Name,CountryId FROM States WHERE CountryId =@CountryId order by Name

END
