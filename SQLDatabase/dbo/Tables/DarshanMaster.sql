CREATE TABLE [dbo].[DarshanMaster] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Darshan]  VARCHAR (50) NOT NULL,
    [IsActive] BIT          CONSTRAINT [DF_DarshanMaster_IsActive] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_DarshanMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

