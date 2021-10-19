CREATE TABLE [dbo].[EmailLog] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [EmailId]          VARCHAR (50)   NOT NULL,
    [Status]           VARCHAR (50)   NOT NULL,
    [Type]             VARCHAR (50)   NOT NULL,
    [DateTimeToSend]   DATETIME       NULL,
    [VaishnavId]       INT            NULL,
    [ReceiptId]        INT            NULL,
    [PadhramaniId]     INT            NULL,
    [PadhramaniStatus] VARCHAR (50)   NULL,
    [CreatedOn]        DATETIME       CONSTRAINT [DF_EmailLog_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]        INT            NULL,
    [SentTime]         DATETIME       NULL,
    [IsSent]           BIT            CONSTRAINT [DF_EmailLog_IsSent] DEFAULT ((0)) NULL,
    [EmailContent]     NVARCHAR (MAX) NULL,
    [EmailSubject]     VARCHAR (50)   NULL,
    CONSTRAINT [PK_EmailLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

