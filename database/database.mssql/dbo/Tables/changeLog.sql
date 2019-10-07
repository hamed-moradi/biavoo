CREATE TABLE [dbo].[changeLog] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [AdminId]    INT              NOT NULL,
    [ActivityId] UNIQUEIDENTIFIER NULL,
    [ActionType] TINYINT          NOT NULL,
    [Entity]     VARCHAR (32)     NOT NULL,
    [EntityId]   BIGINT           NOT NULL,
    [Data]       NVARCHAR (MAX)   NULL,
    [CreatedAt]  DATETIME         CONSTRAINT [DF_ChangeLog_CreatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ChangeLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);

