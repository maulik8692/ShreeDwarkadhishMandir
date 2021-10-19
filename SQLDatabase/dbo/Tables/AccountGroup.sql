CREATE TABLE [dbo].[AccountGroup] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [GroupName]      VARCHAR (100) NOT NULL,
    [AliasName]      VARCHAR (100) NULL,
    [DefaultGroupId] INT           NOT NULL,
    [GroupType]      INT           CONSTRAINT [DF_AccountGroup_GroupType] DEFAULT ((0)) NOT NULL,
    [IsActive]       BIT           CONSTRAINT [DF_AccountGroup_IsActive] DEFAULT ((1)) NOT NULL,
    [IsEditable]     BIT           CONSTRAINT [DF_AccountGroup_IsEditable] DEFAULT ((0)) NOT NULL,
    [CreatedBy]      INT           NOT NULL,
    [CreatedOn]      DATETIME      CONSTRAINT [DF_AccountGroup_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]      INT           NULL,
    [UpdatedOn]      DATETIME      NULL,
    [DeletedBy]      INT           NULL,
    [DeletedOn]      DATETIME      NULL,
    [IsDelete]       BIT           CONSTRAINT [DF_AccountGroup_IsDelete] DEFAULT ((0)) NOT NULL,
    [AnnexureOrder]  INT           NULL,
    [AnnexureName]   VARCHAR (50)  NULL,
    CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountGroup_DefaultGroups] FOREIGN KEY ([DefaultGroupId]) REFERENCES [dbo].[DefaultGroups] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0 - Default
1 - Bank
2 - FD
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'AccountGroup', @level2type = N'COLUMN', @level2name = N'GroupType';

