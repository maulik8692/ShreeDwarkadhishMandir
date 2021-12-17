CREATE TABLE [dbo].[PageModule] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Module]        VARCHAR (500) NOT NULL,
    [SubModule]     VARCHAR (500) NULL,
    [Controller]    VARCHAR (500) NOT NULL,
    [ActionMenthod] VARCHAR (500) NOT NULL,
    [PageUrl]       VARCHAR (500) NOT NULL,
    [Type]          VARCHAR (50)  NULL,
    [CreatedOn]     DATETIME      CONSTRAINT [DF_PageModule_CreatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PageModule] PRIMARY KEY CLUSTERED ([Id] ASC)
);

