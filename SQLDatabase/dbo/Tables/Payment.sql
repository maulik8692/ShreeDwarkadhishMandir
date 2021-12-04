CREATE TABLE [dbo].[Payment] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [PaymentName]     VARCHAR (50) NOT NULL,
    [IsActive]        BIT          CONSTRAINT [DF_Payment_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]       DATETIME     CONSTRAINT [DF_Payment_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [IsDefaultRecord] BIT          CONSTRAINT [D_Payment_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED ([Id] ASC)
);



