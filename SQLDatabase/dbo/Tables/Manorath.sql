CREATE TABLE [dbo].[Manorath] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [ManorathName]      VARCHAR (50)    NOT NULL,
    [Nyochhawar]        DECIMAL (18, 2) NOT NULL,
    [ManorathType]      INT             NOT NULL,
    [CashAccountId]     INT             NOT NULL,
    [ChequeAccountId]   INT             NULL,
    [VaishnavAccountId] INT             NULL,
    [DarshanId]         INT             NULL,
    [IsActive]          BIT             CONSTRAINT [DF_Manorath_IsActive] DEFAULT ((1)) NOT NULL,
    [IsDeleted]         BIT             CONSTRAINT [DF_Manorath_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]         DATETIME        CONSTRAINT [DF_Manorath_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         INT             NOT NULL,
    [UpdatedOn]         DATETIME        NULL,
    [UpdatedBy]         INT             NULL,
    [DeletedOn]         DATETIME        NULL,
    [DeletedBy]         INT             NULL,
    CONSTRAINT [PK_Manorath] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Manorath_AccountHead] FOREIGN KEY ([VaishnavAccountId]) REFERENCES [dbo].[AccountHead] ([Id]),
    CONSTRAINT [FK_Manorath_DarshanMaster] FOREIGN KEY ([DarshanId]) REFERENCES [dbo].[DarshanMaster] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 : Regular Bhet
2 : Darshan
3 : Manorath', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Manorath', @level2type = N'COLUMN', @level2name = N'ManorathType';

