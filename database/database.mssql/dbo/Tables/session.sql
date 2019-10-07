CREATE TABLE [dbo].[session] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [UserId]     INT           NOT NULL,
    [Token]      CHAR (32)     NOT NULL,
    [DeviceId]   VARCHAR (128) NOT NULL,
    [IP]         VARCHAR (16)  NOT NULL,
    [OS]         VARCHAR (128) NULL,
    [Version]    VARCHAR (128) NULL,
    [DeviceName] VARCHAR (128) NULL,
    [Browser]    VARCHAR (128) NULL,
    [TimeZone]   VARCHAR (16)  NULL,
    [Language]   VARCHAR (8)   NULL,
    [FCM]        VARCHAR (MAX) NULL,
    [ModifiedAt] DATETIME      CONSTRAINT [DF_session_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [CreatedAt]  DATETIME      NOT NULL,
    [Status]     TINYINT       NOT NULL,
    CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Session_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[user] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Session$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'session';

