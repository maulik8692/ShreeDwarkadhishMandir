CREATE PROCEDURE [dbo].[GetCountryAll]
AS
BEGIN

SELECT Id,Sortname,Name+' - '+Sortname as Name,PhoneCode FROM Countries order by Name--WHERE name ='india' 

END
