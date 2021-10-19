-- =============================================
-- Author:		<Author,,Maulik Shah>
-- Create date: <Create Date, ,16-Sep-2018>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION GenerateVaishnavId 
(
	@Id int
)
RETURNS varchar(25)
AS
BEGIN
	DECLARE @Random INT;
	DECLARE @Upper INT;
	DECLARE @Lower INT
	 
	---- This will create a random number between 1 and 999
	SET @Lower = 100000 ---- The lowest random number
	SET @Upper = 999999 ---- The highest random number

	DECLARE @rndValue DECIMAL(18,18)
	SELECT @rndValue = RandomNumber
	FROM RandomNumber

	SELECT @Random = ROUND(((@Upper - @Lower -1) * @rndValue + @Lower), 0)

	-- Return the result of the function
	RETURN 'V'+RIGHT('00000' + CONVERT(VARCHAR(8), @Id) + CONVERT(VARCHAR(8),@Random), 15)

END
