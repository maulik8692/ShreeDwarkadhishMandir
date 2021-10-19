CREATE TABLE [dbo].[ManorathReceipt] (
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
    [CreatedOn]       DATETIME        CONSTRAINT [DF_ManorathReceipt_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ChequeBank]      VARCHAR (50)    NULL,
    [ChequeBranch]    VARCHAR (50)    NULL,
    [ChequeNumber]    VARCHAR (50)    NULL,
    [ChequeDate]      DATE            NULL,
    [ChequeStatus]    INT             NULL,
    [Description]     VARCHAR (500)   NULL,
    CONSTRAINT [PK_ManorathReceipt] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ManorathReceipt_AccountHead] FOREIGN KEY ([CashAccountId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_ManorathReceipt_AccountHead1] FOREIGN KEY ([ChequeAccountId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_ManorathReceipt_Manorath] FOREIGN KEY ([ManorathId]) REFERENCES [dbo].[Manorath] ([Id]),
    CONSTRAINT [FK_ManorathReceipt_Payment] FOREIGN KEY ([PaymentId]) REFERENCES [dbo].[Payment] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Null : Payment type is not cheque
0 : In clearing
1 : Clear and amount transferred
2 : Cheque bounce', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ManorathReceipt', @level2type = N'COLUMN', @level2name = N'ChequeStatus';

