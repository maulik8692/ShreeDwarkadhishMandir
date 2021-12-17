CREATE TABLE [dbo].[PageRoleNRights] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [UserId]     INT      NOT NULL,
    [UserTypeId] INT      NOT NULL,
    [PageId]     INT      NOT NULL,
    [IsAllowed]  BIT      NOT NULL,
    [CreatedOn]  DATETIME CONSTRAINT [DF_PageRoleNRights_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]  INT      NOT NULL,
    [UpdatedOn]  DATETIME NULL,
    [UpdatedBy]  INT      NULL,
    CONSTRAINT [PK_PageRoleNRights] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PageRoleNRights_ApplicationUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[ApplicationUser] ([Id]),
    CONSTRAINT [FK_PageRoleNRights_PageModule] FOREIGN KEY ([PageId]) REFERENCES [dbo].[PageModule] ([Id]),
    CONSTRAINT [FK_PageRoleNRights_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [dbo].[UserType] ([Id])
);

