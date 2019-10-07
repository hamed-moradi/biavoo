CREATE TABLE [dbo].[notification] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Body]          NVARCHAR (MAX) NOT NULL,
    [UserCount]     INT            NOT NULL,
    [CreatorId]     INT            NULL,
    [CreatorUserId] INT            NULL,
    [CreatedAt]     SMALLDATETIME  NOT NULL,
    [Status]        TINYINT        NOT NULL,
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([Id] ASC)
);

