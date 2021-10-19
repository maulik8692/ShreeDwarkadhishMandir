CREATE TABLE [dbo].[MandirVoucher] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [VoucherNo]     INT             NOT NULL,
    [VoucherDate]   DATETIME        NOT NULL,
    [AccountId]     INT             NOT NULL,
    [VoucherAmount] DECIMAL (18, 5) NOT NULL,
    [Description]   NVARCHAR (2000) NULL,
    [CreatedOn]     DATETIME        CONSTRAINT [DF_MandirVoucher_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     INT             NOT NULL,
    [VoucherType]   VARCHAR (50)    NULL,
    CONSTRAINT [PK_MandirVoucher] PRIMARY KEY CLUSTERED ([Id] ASC)
);

