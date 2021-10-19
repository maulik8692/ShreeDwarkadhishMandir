CREATE TABLE [dbo].[Samagri] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [BhandarId]   INT            NOT NULL,
    [Recipe]      VARCHAR (1000) NULL,
    [Description] VARCHAR (100)  NULL,
    [IsActive]    BIT            CONSTRAINT [DF_Samagri_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_Samagri_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT            NOT NULL,
    [UpdatedOn]   DATETIME       NULL,
    [UpdatedBy]   INT            NULL,
    [DeletedOn]   DATETIME       NULL,
    [DeletedBy]   INT            NULL,
    [IsDeleted]   BIT            CONSTRAINT [DF_Samagri_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Samagri] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Samagri_Bhandar] FOREIGN KEY ([BhandarId]) REFERENCES [dbo].[Bhandar] ([Id])
);

