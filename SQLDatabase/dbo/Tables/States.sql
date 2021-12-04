CREATE TABLE [dbo].[States] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (50) NOT NULL,
    [CountryId]       INT          NOT NULL,
    [IsDefaultRecord] BIT          CONSTRAINT [D_States_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([Id] ASC)
);



