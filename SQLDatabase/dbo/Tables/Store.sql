CREATE TABLE [dbo].[Store] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [MandirId]    INT             CONSTRAINT [DF_Store_MandirId] DEFAULT ((1)) NOT NULL,
    [Name]        NVARCHAR (500)  NOT NULL,
    [Description] NVARCHAR (1000) NOT NULL,
    [IsActive]    BIT             CONSTRAINT [DF_Store_IsActive] DEFAULT ((0)) NOT NULL,
    [IsMainStore] BIT             CONSTRAINT [DF_Store_IsMainStore] DEFAULT ((0)) NOT NULL,
    [StoreType]   INT             CONSTRAINT [DF_Store_StoreType] DEFAULT ((0)) NOT NULL,
    [CreatedOn]   DATETIME        CONSTRAINT [DF_Store_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT             NOT NULL,
    [UpdatedOn]   DATETIME        NULL,
    [UpdatedBy]   INT             NULL,
    [DeletedOn]   DATETIME        NULL,
    [DeletedBy]   INT             NULL,
    [IsDeleted]   BIT             CONSTRAINT [DF_Store_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Store_Mandir] FOREIGN KEY ([MandirId]) REFERENCES [dbo].[Mandir] ([Id])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1. Bhandar Ghar
2. Rasoi Ghar
3. Bhet Ghar / Prasad Ghar
0. Other', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Store', @level2type = N'COLUMN', @level2name = N'StoreType';

