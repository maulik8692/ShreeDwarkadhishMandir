CREATE TABLE [dbo].[ServiceLog] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [ServiceId]   INT      NOT NULL,
    [RunDateTime] DATETIME NOT NULL,
    [Staus]       BIT      NOT NULL,
    CONSTRAINT [PK_ServiceLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

