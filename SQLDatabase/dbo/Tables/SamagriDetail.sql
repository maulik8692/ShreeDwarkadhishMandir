CREATE TABLE [dbo].[SamagriDetail] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [SamagriId] INT             NOT NULL,
    [BhandarId] INT             NOT NULL,
    [UnitId]    INT             NOT NULL,
    [Quantity]  DECIMAL (18, 5) NOT NULL,
    [IsOut]     BIT             CONSTRAINT [DF_SamagriDetail_IsOut] DEFAULT ((0)) NOT NULL,
    [CreatedOn] DATETIME        CONSTRAINT [DF_SamagriDetail_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy] INT             NOT NULL,
    [UpdatedOn] DATETIME        NULL,
    [UpdatedBy] INT             NULL,
    [DeletedOn] DATETIME        NULL,
    [DeletedBy] INT             NULL,
    [IsDeleted] BIT             CONSTRAINT [DF_SamagriDetail_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_SamagriDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SamagriDetail_Bhandar] FOREIGN KEY ([BhandarId]) REFERENCES [dbo].[Bhandar] ([Id]),
    CONSTRAINT [FK_SamagriDetail_Samagri] FOREIGN KEY ([SamagriId]) REFERENCES [dbo].[Samagri] ([Id])
);

