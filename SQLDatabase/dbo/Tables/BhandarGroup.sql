CREATE TABLE [dbo].[BhandarGroup] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [MandirId]    INT            CONSTRAINT [DF_BhandarGroup_MandirId] DEFAULT ((1)) NOT NULL,
    [Name]        NVARCHAR (150) NOT NULL,
    [GroupCode]   NVARCHAR (500) NULL,
    [Description] NVARCHAR (500) NULL,
    [IsJewellery] BIT            CONSTRAINT [DF_BhandarGroup_IsJewellery] DEFAULT ((0)) NOT NULL,
    [IsSamagri]   BIT            CONSTRAINT [DF_BhandarGroup_IsSamagri] DEFAULT ((0)) NOT NULL,
    [IsBhandar]   BIT            CONSTRAINT [DF_BhandarGroup_IsBhandar] DEFAULT ((0)) NOT NULL,
    [IsActive]    BIT            CONSTRAINT [DF_BhandarGroup_IsEnable] DEFAULT ((0)) NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_BhandarGroup_CreatedBy] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]   INT            NOT NULL,
    [UpdatedOn]   DATETIME       NULL,
    [UpdatedBy]   INT            NULL,
    [DeletedOn]   DATETIME       NULL,
    [DeletedBy]   INT            NULL,
    [IsDeleted]   BIT            CONSTRAINT [DF_BhandarGroup_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_BhandarGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BhandarGroup_Mandir] FOREIGN KEY ([MandirId]) REFERENCES [dbo].[Mandir] ([Id])
);

