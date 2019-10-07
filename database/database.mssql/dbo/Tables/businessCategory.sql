CREATE TABLE [dbo].[businessCategory] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Priority]    SMALLINT       NOT NULL,
    [ThumbImage]  NVARCHAR (512) CONSTRAINT [DF_Category_ThumbImage] DEFAULT (' ') NULL,
    [CreatedAt]   DATETIME       NOT NULL,
    [Status]      TINYINT        NOT NULL,
    CONSTRAINT [PK_businessCategory] PRIMARY KEY CLUSTERED ([Id] DESC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Category$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'businessCategory';

