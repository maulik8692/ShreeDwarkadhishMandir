CREATE TABLE [dbo].[BhandarStoreBalance] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [BhandarId] INT             NOT NULL,
    [StoreId]   INT             NOT NULL,
    [UnitId]    INT             NOT NULL,
    [Balance]   DECIMAL (18, 5) NOT NULL,
    CONSTRAINT [PK_BhandarStoreBalance] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BhandarStoreBalance_Bhandar] FOREIGN KEY ([BhandarId]) REFERENCES [dbo].[Bhandar] ([Id]),
    CONSTRAINT [FK_BhandarStoreBalance_Store] FOREIGN KEY ([StoreId]) REFERENCES [dbo].[Store] ([Id]),
    CONSTRAINT [FK_BhandarStoreBalance_UnitOfMeasurement] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UnitOfMeasurement] ([Id])
);

