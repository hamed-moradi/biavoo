CREATE TABLE [dbo].[comment] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NOT NULL,
    [ParentId]   INT            NULL,
    [EntityId]   BIGINT         NOT NULL,
    [Entity]     VARCHAR (32)   NOT NULL,
    [Body]       NVARCHAR (MAX) NOT NULL,
    [CreatedAt]  DATETIME       NOT NULL,
    [ModifiedAt] DATETIME       NOT NULL,
    [Status]     TINYINT        NOT NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED ([Id] DESC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Comment$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'comment';

