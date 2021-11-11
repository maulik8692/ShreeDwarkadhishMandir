﻿CREATE TABLE [dbo].[BhandarTransaction] (
    [Id]                       INT              IDENTITY (1, 1) NOT NULL,
    [BhandarId]                INT              NOT NULL,
    [StoreId]                  INT              NOT NULL,
    [BhandarTransactionCodeId] INT              NOT NULL,
    [UnitId]                   INT              NOT NULL,
    [SupplierId]               INT              NULL,
    [SamagriId]                INT              NULL,
    [VaishnavId]               INT              NULL,
    [AccountHeadId]            INT              NULL,
    [StockTransactionQuantity] DECIMAL (18, 5)  NOT NULL,
    [Price]                    DECIMAL (18, 2)  NOT NULL,
    [Description]              NVARCHAR (1000)  NULL,
    [JewelleryUnitId]          INT              NULL,
    [JewelleryQuantity]        DECIMAL (18, 5)  NULL,
    [OriginalUnitId]           INT              NOT NULL,
    [IncomeAccountId]          INT              NULL,
    [ExpensesAccountId]        INT              NULL,
    [TransactionId]            UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]                DATETIME         CONSTRAINT [DF_BhandarTransaction_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]                INT              NOT NULL,
    CONSTRAINT [PK_BhandarTransaction] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BhandarTransaction_AccountHead] FOREIGN KEY ([AccountHeadId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_AccountHead1] FOREIGN KEY ([IncomeAccountId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_AccountHead2] FOREIGN KEY ([ExpensesAccountId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_Bhandar] FOREIGN KEY ([BhandarId]) REFERENCES [dbo].[Bhandar] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_BhandarTransactionCode] FOREIGN KEY ([BhandarTransactionCodeId]) REFERENCES [dbo].[BhandarTransactionCode] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_Samagri] FOREIGN KEY ([SamagriId]) REFERENCES [dbo].[Samagri] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_UnitOfMeasurement] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UnitOfMeasurement] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_UnitOfMeasurement1] FOREIGN KEY ([JewelleryUnitId]) REFERENCES [dbo].[UnitOfMeasurement] ([Id]),
    CONSTRAINT [FK_BhandarTransaction_Vaishnav] FOREIGN KEY ([VaishnavId]) REFERENCES [dbo].[Vaishnav] ([Id])
);





