CREATE TABLE [dbo].[UserType] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [TypeName]  VARCHAR (25) NOT NULL,
    [CreadedOn] DATETIME     CONSTRAINT [DF_UserType_CreadedOn] DEFAULT (getdate()) NOT NULL,
    [DeletedOn] DATETIME     NULL,
    [IsDeleted] BIT          CONSTRAINT [DF_UserType_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

