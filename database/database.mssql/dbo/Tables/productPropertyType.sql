CREATE TABLE [dbo].[productPropertyType] (
    [Id]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (512) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_productPropertyType_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_productPropertyType_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_ProductPropertyType] PRIMARY KEY CLUSTERED ([Id] DESC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'User$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'productPropertyType';

