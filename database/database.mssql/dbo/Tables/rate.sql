CREATE TABLE [dbo].[rate] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Point]     DECIMAL (2, 1) NOT NULL,
    [Body]      NVARCHAR (MAX) NULL,
    [ReplyTo]   INT            NULL,
    [UserId]    INT            NULL,
    [AdminId]   INT            NULL,
    [GameId]    INT            NOT NULL,
    [CreatedAt] DATETIME       NOT NULL,
    [UpdatedAt] DATETIME       NULL,
    [UpdaterId] INT            NULL,
    [Status]    TINYINT        NOT NULL,
    CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rate_Rate] FOREIGN KEY ([ReplyTo]) REFERENCES [dbo].[rate] ([Id]),
    CONSTRAINT [IX_Rate] UNIQUE NONCLUSTERED ([GameId] ASC, [UserId] ASC)
);


GO
ALTER TABLE [dbo].[rate] NOCHECK CONSTRAINT [FK_Rate_Rate];


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Rate$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'rate';

