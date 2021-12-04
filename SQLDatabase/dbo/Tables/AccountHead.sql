﻿CREATE TABLE [dbo].[AccountHead] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [MandirId]          INT             NOT NULL,
    [GroupId]           INT             NOT NULL,
    [AccountName]       VARCHAR (50)    NOT NULL,
    [Alias]             VARCHAR (50)    NULL,
    [BalanceAmount]     DECIMAL (18, 4) NULL,
    [DebitCredit]       VARCHAR (50)    NULL,
    [AccountHolderName] VARCHAR (50)    NULL,
    [BankName]          VARCHAR (50)    NULL,
    [BankAddress]       VARCHAR (500)   NULL,
    [AccountNumber]     VARCHAR (50)    NULL,
    [IFSCCode]          VARCHAR (50)    NULL,
    [BankBranch]        VARCHAR (50)    NULL,
    [DateOfIssue]       DATETIME        NULL,
    [DateOfMaturity]    DATETIME        NULL,
    [InterestRate]      DECIMAL (18, 4) NULL,
    [MaturityAmount]    DECIMAL (18, 4) NULL,
    [IsEditable]        BIT             CONSTRAINT [DF_AccountHead_IsEditable] DEFAULT ((1)) NULL,
    [IsActive]          BIT             CONSTRAINT [DF_AccountHead_IsActive] DEFAULT ((0)) NULL,
    [CreatedBy]         INT             NOT NULL,
    [CreatedOn]         DATETIME        CONSTRAINT [DF_AccountHead_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdateBy]          INT             NULL,
    [UpdateOn]          DATETIME        NULL,
    [DeletedBy]         INT             NULL,
    [DeletedOn]         DATETIME        NULL,
    [IsDeleted]         BIT             CONSTRAINT [DF_AccountHead_IsDeleted] DEFAULT ((0)) NOT NULL,
    [AnnexureOrder]     INT             NULL,
    [AnnexureName]      VARCHAR (50)    NULL,
    [SupplierId]        INT             NULL,
    [IsBankAccount]     BIT             CONSTRAINT [DF_AccountHead_IsBankAccount] DEFAULT ((0)) NULL,
    [IsCashOnHand]      BIT             CONSTRAINT [DF_AccountHead_IsCashOnHand] DEFAULT ((0)) NULL,
    [IsDefaultRecord]   BIT             CONSTRAINT [D_AccountHead_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_AccountHead] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountHead_AccountGroup] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[AccountGroup] ([Id]),
    CONSTRAINT [FK_AccountHead_Supplier] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id])
);



