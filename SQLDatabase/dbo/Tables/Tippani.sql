CREATE TABLE [dbo].[Tippani] (
    [Id]                     INT             IDENTITY (1, 1) NOT NULL,
    [VrajMonth]              NVARCHAR (1000) NOT NULL,
    [VrajMonthPart]          NVARCHAR (1000) NOT NULL,
    [VrajTithi]              NVARCHAR (1000) NOT NULL,
    [GujratiMonth]           NVARCHAR (1000) NOT NULL,
    [GujratiMonthPart]       NVARCHAR (1000) NOT NULL,
    [GujratiTithi]           NVARCHAR (1000) NOT NULL,
    [TippaniNotes]           NVARCHAR (1000) NOT NULL,
    [UtsavDetail]            NVARCHAR (1000) NOT NULL,
    [IsUtsavDisplayInDetail] BIT             CONSTRAINT [DF_Tippani_IsUtsavDisplayInDetail] DEFAULT ((0)) NOT NULL,
    [IsJanmdinUtsav]         BIT             CONSTRAINT [DF_Tippani_IsJanmdinUtsav] DEFAULT ((0)) NOT NULL,
    [IsVadhai]               BIT             CONSTRAINT [DF_Tippani_IsVadhai] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Tippani] PRIMARY KEY CLUSTERED ([Id] ASC)
);

