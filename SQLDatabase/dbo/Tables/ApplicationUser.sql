CREATE TABLE [dbo].[ApplicationUser] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [DisplayName] VARCHAR (50)  NOT NULL,
    [UserName]    VARCHAR (50)  NOT NULL,
    [Password]    VARCHAR (500) NOT NULL,
    [Address]     VARCHAR (500) NULL,
    [Email]       VARCHAR (50)  NULL,
    [PhoneNumber] VARCHAR (50)  NULL,
    [MandirId]    INT           NOT NULL,
    [UserTypeId]  INT           NOT NULL,
    [CreatedBy]   INT           NOT NULL,
    [CreatedOn]   DATETIME      CONSTRAINT [DF_ApplicationUser_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   INT           NULL,
    [UpdatedOn]   DATETIME      NULL,
    [DeletedBy]   INT           NULL,
    [DeletedOn]   DATETIME      NULL,
    [IsDeleted]   BIT           CONSTRAINT [DF_ApplicationUser_IsDeleted] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_ApplicationUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

