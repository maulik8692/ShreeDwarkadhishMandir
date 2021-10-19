CREATE TABLE [dbo].[Villages] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Village]    NVARCHAR (4000) NOT NULL,
    [PostalCode] NVARCHAR (4000) NOT NULL,
    [CityId]     INT             NOT NULL,
    CONSTRAINT [PK_Villages] PRIMARY KEY CLUSTERED ([Id] ASC)
);

