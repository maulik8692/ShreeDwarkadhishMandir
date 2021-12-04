CREATE TABLE [dbo].[ServiceStatus] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [ServiceName]     VARCHAR (50) NOT NULL,
    [IsRunning]       BIT          CONSTRAINT [DF_ServiceStatus_IsRunning] DEFAULT ((0)) NOT NULL,
    [TimeInterval]    INT          NOT NULL,
    [IsActive]        BIT          CONSTRAINT [DF_ServiceStatus_IsActive] DEFAULT ((0)) NOT NULL,
    [IsDefaultRecord] BIT          CONSTRAINT [D_ServiceStatus_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_ServiceStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Time Interval will be in amount of millisecond:
i.e. : 5000 = 5 seconds', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ServiceStatus', @level2type = N'COLUMN', @level2name = N'TimeInterval';

