CREATE TABLE [dbo].[product] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [BusinessId]  INT            NOT NULL,
    [CategoryId]  INT            NOT NULL,
    [Title]       NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Thumbnail]   NVARCHAR (512) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_product_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [ModifiedAt]  DATETIME       CONSTRAINT [DF_product_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_product_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] DESC)
);

