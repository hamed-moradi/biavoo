CREATE TABLE [dbo].[image] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [EntityId]    INT            NOT NULL,
    [ScaleId]     INT            NOT NULL,
    [Entity]      VARCHAR (32)   NOT NULL,
    [Name]        NVARCHAR (128) NOT NULL,
    [Extension]   NVARCHAR (8)   NOT NULL,
    [Path]        NVARCHAR (512) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_Image_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [ModifiedAt]  DATETIME       CONSTRAINT [DF_Image_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_Image_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED ([Id] DESC)
);

