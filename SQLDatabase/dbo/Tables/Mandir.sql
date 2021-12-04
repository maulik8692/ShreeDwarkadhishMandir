﻿CREATE TABLE [dbo].[Mandir] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Name]               VARCHAR (150)  NOT NULL,
    [ImageUrl]           VARCHAR (100)  NULL,
    [Address]            VARCHAR (500)  NOT NULL,
    [CountryId]          INT            NOT NULL,
    [StateId]            INT            NOT NULL,
    [CityId]             INT            NOT NULL,
    [VillageId]          INT            NULL,
    [PostalCode]         VARCHAR (10)   NOT NULL,
    [PhoneNumber]        VARCHAR (50)   NULL,
    [Email]              VARCHAR (50)   NULL,
    [CreatedBy]          INT            NOT NULL,
    [CreatedOn]          DATETIME       CONSTRAINT [DF_Mandir_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]          INT            NULL,
    [UpdatedOn]          DATETIME       NULL,
    [DeletedBy]          INT            NULL,
    [DeletedOn]          DATETIME       NULL,
    [IsDeleted]          BIT            CONSTRAINT [DF_Mandir_IsDeleted] DEFAULT ((0)) NOT NULL,
    [RegistrationNumber] NVARCHAR (100) NULL,
    [GurudevName]        NVARCHAR (500) NULL,
    [MandirHeader]       NVARCHAR (150) NULL,
    [IsDefaultRecord]    BIT            CONSTRAINT [D_Mandir_IsDefaultRecord] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Mandir] PRIMARY KEY CLUSTERED ([Id] ASC)
);



