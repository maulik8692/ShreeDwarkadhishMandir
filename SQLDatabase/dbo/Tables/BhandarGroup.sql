CREATE TABLE [dbo].[BhandarGroup] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [MandirId]        INT            CONSTRAINT [DF_BhandarGroup_MandirId] DEFAULT ((1)) NOT NULL,
    [Name]            NVARCHAR (150) NOT NULL,
    [GroupCode]       NVARCHAR (500) NULL,
    [Description]     NVARCHAR (500) NULL,
    [GroupType]       INT            CONSTRAINT [DF_BhandarGroup_GroupType] DEFAULT ((0)) NULL,
    [IsActive]        BIT            CONSTRAINT [DF_BhandarGroup_IsEnable] DEFAULT ((0)) NULL,
    [CreatedOn]       DATETIME       CONSTRAINT [DF_BhandarGroup_CreatedBy] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]       INT            NOT NULL,
    [UpdatedOn]       DATETIME       NULL,
    [UpdatedBy]       INT            NULL,
    [DeletedOn]       DATETIME       NULL,
    [DeletedBy]       INT            NULL,
    [IsDeleted]       BIT            CONSTRAINT [DF_BhandarGroup_IsDeleted] DEFAULT ((0)) NULL,
    [IsDefaultRecord] BIT            CONSTRAINT [D_BhandarGroup_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BhandarGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BhandarGroup_Mandir] FOREIGN KEY ([MandirId]) REFERENCES [dbo].[Mandir] ([Id])
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0 General
1 Jewellery
2 Samagri
3 Bhandar
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'BhandarGroup', @level2type = N'COLUMN', @level2name = N'GroupType';

