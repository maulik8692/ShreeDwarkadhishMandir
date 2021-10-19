CREATE TABLE [dbo].[DefaultGroups] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [GroupName]     VARCHAR (100) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_DefaultGroups_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedOn]     DATETIME      CONSTRAINT [DF_DefaultGroups_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [NatureOfGroup] VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_DefaultGroups] PRIMARY KEY CLUSTERED ([Id] ASC)
);

