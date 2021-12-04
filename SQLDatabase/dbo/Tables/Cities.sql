CREATE TABLE [dbo].[Cities] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (150) NOT NULL,
    [StateId]         INT           NOT NULL,
    [IsDefaultRecord] BIT           CONSTRAINT [D_Cities_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([Id] ASC)
);



