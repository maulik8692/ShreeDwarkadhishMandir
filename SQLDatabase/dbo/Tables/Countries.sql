CREATE TABLE [dbo].[Countries] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [SortName]  VARCHAR (3)   NOT NULL,
    [Name]      VARCHAR (150) NOT NULL,
    [PhoneCode] INT           NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id] ASC)
);

