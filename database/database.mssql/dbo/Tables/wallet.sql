CREATE TABLE [dbo].[wallet] (
    [UserId]    INT           NOT NULL,
    [Cash]      INT           NOT NULL,
    [Status]    TINYINT       NOT NULL,
    [UpdatedAt] SMALLDATETIME NULL,
    [CreatedAt] SMALLDATETIME NOT NULL,
    [UpdaterId] INT           NULL,
    CONSTRAINT [PK_Wallet] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Wallet$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'wallet';

