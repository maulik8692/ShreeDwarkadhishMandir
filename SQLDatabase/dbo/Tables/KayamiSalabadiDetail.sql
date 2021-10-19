CREATE TABLE [dbo].[KayamiSalabadiDetail] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [VaishnavId]         INT             NOT NULL,
    [ManorathReceiptId]  INT             NOT NULL,
    [ManorathTithiMaas]  NVARCHAR (2000) NOT NULL,
    [ManorathTithiPaksh] NVARCHAR (2000) NOT NULL,
    [ManorathTithi]      NVARCHAR (2000) NOT NULL,
    [StartDate]          DATE            NOT NULL,
    [EndDate]            DATE            NOT NULL,
    [CreatedOn]          DATETIME        CONSTRAINT [DF_KayamiSalabadiDetail_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]          INT             NOT NULL,
    [UpdatedOn]          DATETIME        NULL,
    [UpdatedBy]          INT             NULL,
    [DeletedOn]          DATETIME        NULL,
    [DeletedBy]          INT             NULL,
    [IsDeleted]          BIT             CONSTRAINT [DF_KayamiSalabadiDetail_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_KayamiSalabadiDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_KayamiSalabadiDetail_ApplicationUser] FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[ApplicationUser] ([Id]),
    CONSTRAINT [FK_KayamiSalabadiDetail_ApplicationUser1] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[ApplicationUser] ([Id]),
    CONSTRAINT [FK_KayamiSalabadiDetail_ApplicationUser2] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[ApplicationUser] ([Id]),
    CONSTRAINT [FK_KayamiSalabadiDetail_ManorathReceipt] FOREIGN KEY ([ManorathReceiptId]) REFERENCES [dbo].[ManorathReceipt] ([Id]),
    CONSTRAINT [FK_KayamiSalabadiDetail_Vaishnav] FOREIGN KEY ([VaishnavId]) REFERENCES [dbo].[Vaishnav] ([Id])
);

