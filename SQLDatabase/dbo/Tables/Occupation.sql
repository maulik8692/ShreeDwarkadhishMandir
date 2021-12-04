CREATE TABLE [dbo].[Occupation] (
    [Id]              FLOAT (53)     NULL,
    [Professions]     NVARCHAR (255) NULL,
    [IsDefaultRecord] BIT            CONSTRAINT [D_Occupation_IsDefaultRecord] DEFAULT ((1)) NOT NULL
);



