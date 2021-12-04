﻿CREATE TABLE [dbo].[AccountTransaction] (
    [Id]                          INT             IDENTITY (1, 1) NOT NULL,
    [AccountId]                   INT             NOT NULL,
    [Debit]                       DECIMAL (18, 4) NOT NULL,
    [Credit]                      DECIMAL (18, 4) NOT NULL,
    [ActullyDate]                 DATETIME        NOT NULL,
    [IsOpenningBalance]           BIT             CONSTRAINT [DF_AccountTransaction_IsOpenningBalance] DEFAULT ((0)) NOT NULL,
    [MemberId]                    INT             NULL,
    [ManorathId]                  INT             NULL,
    [VoucherId]                   INT             NULL,
    [PaymentId]                   INT             NULL,
    [ManorathReceiptId]           INT             NULL,
    [ChequeBank]                  VARCHAR (50)    NULL,
    [ChequeBranch]                VARCHAR (50)    NULL,
    [ChequeNumber]                VARCHAR (50)    NULL,
    [ChequeDate]                  DATE            NULL,
    [ChequeStatus]                INT             NULL,
    [ReferenceAccountTransaction] INT             NULL,
    [CreatedBy]                   INT             NOT NULL,
    [CreatedOn]                   DATETIME        CONSTRAINT [DF_AccountTrasaction_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]                   INT             NULL,
    [UpdatedOn]                   DATETIME        NULL,
    [DeletedBy]                   INT             NULL,
    [DeletedOn]                   DATETIME        NULL,
    [IsDeleted]                   BIT             CONSTRAINT [DF_AccountTrasaction_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Description]                 NVARCHAR (500)  NULL,
    [MandirVoucherId]             INT             NULL,
    [BhandarTransactionId]        INT             NULL,
    CONSTRAINT [PK_AccountTrasaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountTransaction_AccountHead] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_AccountTransaction_BhandarTransaction] FOREIGN KEY ([BhandarTransactionId]) REFERENCES [dbo].[BhandarTransaction] ([Id]),
    CONSTRAINT [FK_AccountTransaction_MandirVoucher] FOREIGN KEY ([MandirVoucherId]) REFERENCES [dbo].[MandirVoucher] ([Id]),
    CONSTRAINT [FK_AccountTransaction_Manorath] FOREIGN KEY ([ManorathId]) REFERENCES [dbo].[Manorath] ([Id]),
    CONSTRAINT [FK_AccountTransaction_ManorathReceipt] FOREIGN KEY ([ManorathReceiptId]) REFERENCES [dbo].[ManorathReceipt] ([Id]),
    CONSTRAINT [FK_AccountTransaction_Payment] FOREIGN KEY ([PaymentId]) REFERENCES [dbo].[Payment] ([Id]),
    CONSTRAINT [FK_AccountTransaction_Voucher] FOREIGN KEY ([VoucherId]) REFERENCES [dbo].[Voucher] ([Id])
);







