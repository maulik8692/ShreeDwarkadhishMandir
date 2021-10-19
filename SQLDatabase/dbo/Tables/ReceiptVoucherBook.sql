CREATE TABLE [dbo].[ReceiptVoucherBook] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [BookType]      VARCHAR (50)    NULL,
    [ReceiptNoFrom] INT             NULL,
    [ReceiptNoTo]   INT             NULL,
    [DateFrom]      DATE            NULL,
    [DateTo]        DATE            NULL,
    [TotalAmount]   DECIMAL (18, 2) NULL,
    [Note]          VARCHAR (2000)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

