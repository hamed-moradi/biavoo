CREATE TABLE [dbo].[productToTag] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [ProductId] INT      NOT NULL,
    [TagId]     INT      NOT NULL,
    [CreatedAt] DATETIME CONSTRAINT [DF_productToTag_CreatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ProductToTag] PRIMARY KEY CLUSTERED ([Id] DESC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'User$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'productToTag';

