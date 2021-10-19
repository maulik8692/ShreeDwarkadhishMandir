CREATE PROCEDURE GetBookEntry
AS
BEGIN
SELECT
BookType,ReceiptNoFrom,ReceiptNoTo,FORMAT(DateFrom,'dd/MMM/yyyy') DateFrom,FORMAT(DateTo,'dd/MMM/yyyy') DateTo,TotalAmount,Note 
FROM ReceiptVoucherBook as RVB 
ORDER BY RVB.BookType,RVB.DateFrom
END

