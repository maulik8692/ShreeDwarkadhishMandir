CREATE TABLE [dbo].[Supplier] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [MandirId]     INT           NOT NULL,
    [SupplierId]   VARCHAR (50)  NULL,
    [SupplierName] VARCHAR (50)  NOT NULL,
    [Address]      VARCHAR (500) NOT NULL,
    [CountryId]    INT           NOT NULL,
    [StateId]      INT           NOT NULL,
    [CityId]       INT           NOT NULL,
    [VillageId]    INT           CONSTRAINT [DF_Supplier_VillageId] DEFAULT ((0)) NOT NULL,
    [PostalCode]   VARCHAR (10)  NOT NULL,
    [MobileNo]     VARCHAR (50)  NULL,
    [Email]        VARCHAR (50)  NULL,
    [CreatedBy]    INT           NOT NULL,
    [CreatedOn]    DATETIME      CONSTRAINT [DF_Supplier_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]    INT           NULL,
    [UpdatedOn]    DATETIME      NULL,
    [IsActive]     BIT           CONSTRAINT [DF_Supplier_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([Id] ASC)
);

