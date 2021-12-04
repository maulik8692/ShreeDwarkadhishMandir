CREATE TABLE [dbo].[UnitConversion] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [MainUnitId]             INT             NOT NULL,
    [MainUnitQuantity]       DECIMAL (18, 5) CONSTRAINT [DF_UnitConversion_MainUnitQuantity] DEFAULT ((1)) NOT NULL,
    [ConversionUnitId]       INT             NOT NULL,
    [ConversionUnitQuantity] DECIMAL (18, 5) NOT NULL,
    [Createdby]              INT             NULL,
    [CreatedOn]              DATETIME        CONSTRAINT [DF_UnitConversion_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [IsDeleted]              BIT             CONSTRAINT [DF_UnitConversion_IsDeleted] DEFAULT ((0)) NOT NULL,
    [DeletedBy]              INT             NULL,
    [DeletedOn]              DATETIME        NULL,
    [IsDefaultRecord]        BIT             CONSTRAINT [D_UnitConversion_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_UnitConversion] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UnitConversion_UnitOfMeasurement] FOREIGN KEY ([MainUnitId]) REFERENCES [dbo].[UnitOfMeasurement] ([Id]),
    CONSTRAINT [FK_UnitConversion_UnitOfMeasurement_] FOREIGN KEY ([ConversionUnitId]) REFERENCES [dbo].[UnitOfMeasurement] ([Id])
);



