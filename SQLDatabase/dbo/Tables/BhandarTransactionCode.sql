CREATE TABLE [dbo].[BhandarTransactionCode] (
    [Id]                     INT           IDENTITY (1, 1) NOT NULL,
    [TransactionType]        VARCHAR (50)  NOT NULL,
    [TransactionCode]        VARCHAR (50)  NOT NULL,
    [TransactionDescription] VARCHAR (150) NOT NULL,
    [MultiplicationWith]     INT           NOT NULL,
    [CreatedOn]              DATETIME      CONSTRAINT [DF_BhandarTransactionCode_CreatedOn] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_BhandarTransactionCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);

