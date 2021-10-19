CREATE TABLE [dbo].[ManorathReceipt_Backup] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [ReceiptNo]       INT             NOT NULL,
    [Nek]             DECIMAL (18, 2) NOT NULL,
    [ManorathId]      INT             NOT NULL,
    [PaymentId]       INT             NOT NULL,
    [CashAccountId]   INT             NULL,
    [ChequeAccountId] INT             NULL,
    [VaishnavId]      INT             NULL,
    [ManorathiName]   VARCHAR (50)    NULL,
    [Email]           VARCHAR (50)    NULL,
    [MobileNo]        VARCHAR (50)    NULL,
    [ManorathDate]    DATETIME        NULL,
    [CreatedBy]       INT             NOT NULL,
    [CreatedOn]       DATETIME        NOT NULL,
    [ChequeBank]      VARCHAR (50)    NULL,
    [ChequeBranch]    VARCHAR (50)    NULL,
    [ChequeNumber]    VARCHAR (50)    NULL,
    [ChequeDate]      DATE            NULL,
    [ChequeStatus]    INT             NULL,
    [Description]     VARCHAR (500)   NULL
);

