CREATE TABLE [dbo].[Bhandar] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [BhandarCategoryId] INT             NOT NULL,
    [UnitId]            INT             NOT NULL,
    [Name]              NVARCHAR (500)  NOT NULL,
    [Description]       NVARCHAR (1000) NULL,
    [IsActive]          BIT             CONSTRAINT [DF_Bhandar_IsActive] DEFAULT ((0)) NOT NULL,
    [OtherUnitId]       INT             NULL,
    [Balance]           DECIMAL (18, 5) CONSTRAINT [DF_Bhandar_Balance] DEFAULT ((0)) NOT NULL,
    [CreatedOn]         DATETIME        CONSTRAINT [DF_Bhandar_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]         INT             NOT NULL,
    [UpdatedOn]         DATETIME        NULL,
    [UpdatedBy]         INT             NULL,
    [DeletedOn]         DATETIME        NULL,
    [DeletedBy]         INT             NULL,
    [IsDeleted]         BIT             CONSTRAINT [DF_Bhandar_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Bhandar] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bhandar_BhandarCategory] FOREIGN KEY ([BhandarCategoryId]) REFERENCES [dbo].[BhandarCategory] ([Id]),
    CONSTRAINT [FK_Bhandar_UnitConversion] FOREIGN KEY ([OtherUnitId]) REFERENCES [dbo].[UnitConversion] ([Id]),
    CONSTRAINT [FK_Bhandar_UnitOfMeasurement] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[UnitOfMeasurement] ([Id])
);

