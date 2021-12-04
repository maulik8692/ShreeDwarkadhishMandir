CREATE TABLE [dbo].[DarshanMaster] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [Darshan]         VARCHAR (50) NOT NULL,
    [IsActive]        BIT          CONSTRAINT [DF_DarshanMaster_IsActive] DEFAULT ((1)) NULL,
    [IsDefaultRecord] BIT          CONSTRAINT [D_DarshanMaster_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_DarshanMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);



