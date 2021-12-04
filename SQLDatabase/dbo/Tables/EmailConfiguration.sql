CREATE TABLE [dbo].[EmailConfiguration] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Server]          VARCHAR (50) NULL,
    [Port]            INT          NULL,
    [Username]        VARCHAR (50) NULL,
    [Password]        VARCHAR (50) NULL,
    [DisplayName]     VARCHAR (50) NULL,
    [SSL]             BIT          NULL,
    [ExchangeService] BIT          NULL,
    [IsActive]        BIT          CONSTRAINT [DF_EmailConfiguration_IsActive] DEFAULT ((0)) NULL,
    [IsDefaultRecord] BIT          CONSTRAINT [D_EmailConfiguration_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_EmailConfiguration] PRIMARY KEY CLUSTERED ([Id] ASC)
);



