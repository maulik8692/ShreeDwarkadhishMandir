CREATE TABLE [dbo].[AppConfiguration] (
    [Id]                       INT           IDENTITY (1, 1) NOT NULL,
    [KeyName]                  VARCHAR (50)  NOT NULL,
    [KeyValue]                 VARCHAR (500) NOT NULL,
    [IsDeleted]                BIT           NOT NULL,
    [IsDispalyInConfiguration] BIT           CONSTRAINT [DF_AppConfiguration_IsDispalyInConfiguration] DEFAULT ((0)) NULL,
    [KeyDisplayName]           VARCHAR (50)  NULL,
    CONSTRAINT [PK_AppConfiguration] PRIMARY KEY CLUSTERED ([Id] ASC)
);

