CREATE TABLE [dbo].[DarshanTiming] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [DarshanId]   INT           NOT NULL,
    [DarshanDate] DATETIME      NOT NULL,
    [StartTime]   DATETIME      NOT NULL,
    [EndTime]     DATETIME      NOT NULL,
    [Note]        VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_DarshanTiming] PRIMARY KEY CLUSTERED ([Id] ASC)
);

