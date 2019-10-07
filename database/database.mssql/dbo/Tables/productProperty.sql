CREATE TABLE [dbo].[productProperty] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]   INT            NOT NULL,
    [TypeId]      SMALLINT       NOT NULL,
    [Key]         NVARCHAR (512) NOT NULL,
    [Value]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_productProperty_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [ModifiedAt]  DATETIME       CONSTRAINT [DF_productProperty_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_productProperty_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_productProperty] PRIMARY KEY CLUSTERED ([Id] DESC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'User$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'productProperty';

