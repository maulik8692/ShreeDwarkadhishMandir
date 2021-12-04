CREATE TABLE [dbo].[Voucher] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [VoucherName]     VARCHAR (50) NOT NULL,
    [CreatedOn]       DATETIME     CONSTRAINT [DF_Voucher_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [IsActive]        BIT          CONSTRAINT [DF_Voucher_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDefaultRecord] BIT          CONSTRAINT [D_Voucher_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED ([Id] ASC)
);



