CREATE TABLE [dbo].[ReceiptNoCounter] (
    [Id]                INT IDENTITY (1, 1) NOT NULL,
    [BhetReceiptNo]     INT CONSTRAINT [DF_ReceiptNoCounter_BhetReceiptNo] DEFAULT ((0)) NOT NULL,
    [ManorathReceiptNo] INT CONSTRAINT [DF_ReceiptNoCounter_ManorathReceiptNo] DEFAULT ((0)) NOT NULL,
    [DarshanReceiptNo]  INT CONSTRAINT [DF_ReceiptNoCounter_DarshanReceipt] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ReceiptNoCounter] PRIMARY KEY CLUSTERED ([Id] ASC)
);

