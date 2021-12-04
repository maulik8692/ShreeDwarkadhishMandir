CREATE TABLE [dbo].[BhandarCategory] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [GroupId]         INT            NOT NULL,
    [Name]            NVARCHAR (150) NULL,
    [CategoryCode]    NVARCHAR (100) NULL,
    [Description]     NVARCHAR (500) NULL,
    [IsActive]        BIT            CONSTRAINT [DF_BhandarCategory_IsEnable] DEFAULT ((0)) NULL,
    [CreatedOn]       DATETIME       CONSTRAINT [DF_BhandarCategory_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       INT            NULL,
    [UpdatedOn]       DATETIME       NULL,
    [UpdatedBy]       INT            NULL,
    [DeletedOn]       DATETIME       NULL,
    [DeletedBy]       INT            NULL,
    [IsDeleted]       BIT            CONSTRAINT [DF_BhandarCategory_IsDeleted] DEFAULT ((0)) NULL,
    [IsDefaultRecord] BIT            CONSTRAINT [D_BhandarCategory_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BhandarCategory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GropuId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[BhandarGroup] ([Id])
);



