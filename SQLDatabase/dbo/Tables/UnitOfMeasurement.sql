CREATE TABLE [dbo].[UnitOfMeasurement] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [UnitAbbreviation] VARCHAR (50)  NOT NULL,
    [UnitDescription]  VARCHAR (500) NOT NULL,
    [IsActive]         BIT           CONSTRAINT [DF_UnitOfMeasurement_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedOn]        DATETIME      CONSTRAINT [DF_UnitOfMeasurement_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        INT           NOT NULL,
    [UpdatedOn]        DATETIME      NULL,
    [UpdatedBy]        INT           NULL,
    [MandirId]         INT           CONSTRAINT [DF_UnitOfMeasurement_MandirId] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_UnitOfMeasurement] PRIMARY KEY CLUSTERED ([Id] ASC)
);

