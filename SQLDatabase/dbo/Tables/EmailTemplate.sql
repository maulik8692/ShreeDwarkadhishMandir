CREATE TABLE [dbo].[EmailTemplate] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [TempleteName]    VARCHAR (50)   NOT NULL,
    [TempleteType]    VARCHAR (50)   NOT NULL,
    [EmailSubject]    VARCHAR (50)   NOT NULL,
    [TempleteContent] NVARCHAR (MAX) NOT NULL,
    [IsActive]        BIT            CONSTRAINT [DF_EmailTemplate_IsActive] DEFAULT ((0)) NOT NULL,
    [IsDefaultRecord] BIT            CONSTRAINT [D_EmailTemplate_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmailTemplate] PRIMARY KEY CLUSTERED ([Id] ASC)
);



