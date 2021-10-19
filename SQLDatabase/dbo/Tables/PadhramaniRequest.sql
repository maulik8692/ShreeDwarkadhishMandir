CREATE TABLE [dbo].[PadhramaniRequest] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [VallabhId]           INT             NULL,
    [VaishnavId]          INT             NULL,
    [Address]             NVARCHAR (1000) NULL,
    [CountryId]           INT             NULL,
    [StateId]             INT             NULL,
    [CityId]              INT             NULL,
    [VillageId]           INT             NULL,
    [PostalCode]          NVARCHAR (50)   NULL,
    [RequestNumber]       NVARCHAR (50)   NULL,
    [RequestStatus]       INT             CONSTRAINT [DF_PadhramaniRequest_RequestStatus] DEFAULT ((0)) NULL,
    [PadhramaniDate]      DATETIME        NULL,
    [RequestedOn]         DATETIME        CONSTRAINT [DF_Table_1_CreatedOn] DEFAULT (getdate()) NULL,
    [CreatedUserId]       INT             NULL,
    [RequestedVaishnavId] INT             NULL,
    [UpdatedOn]           DATETIME        NULL,
    [UpdatedBy]           INT             NULL,
    [CompletionDate]      DATETIME        NULL,
    [IsCompled]           BIT             CONSTRAINT [DF_PadhramaniRequest_IsCompled] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_PadhramaniRequest] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'0 : Pending
1 : Accepted
2 : LaterOn
3 : Completed', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PadhramaniRequest', @level2type = N'COLUMN', @level2name = N'RequestStatus';

