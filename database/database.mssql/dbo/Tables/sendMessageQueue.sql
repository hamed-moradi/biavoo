CREATE TABLE [dbo].[sendMessageQueue] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [TypeId]     TINYINT        NOT NULL,
    [CategoryId] TINYINT        NOT NULL,
    [CellPhone]  VARCHAR (16)   NULL,
    [Email]      VARCHAR (64)   NULL,
    [Subject]    NVARCHAR (512) NULL,
    [Body]       NVARCHAR (MAX) NOT NULL,
    [Gateway]    VARCHAR (32)   NOT NULL,
    [CreatedAt]  DATETIME       DEFAULT (getdate()) NOT NULL,
    [ModifiedAt] DATETIME       DEFAULT (getdate()) NOT NULL,
    [Status]     TINYINT        DEFAULT ((100)) NOT NULL,
    CONSTRAINT [PK_sendMessageQueue] PRIMARY KEY CLUSTERED ([Id] DESC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'صف ارسال پیام ها', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'sendMessageQueue';

