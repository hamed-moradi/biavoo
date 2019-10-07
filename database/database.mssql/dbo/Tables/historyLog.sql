CREATE TABLE [dbo].[historyLog] (
    [Id]           BIGINT           IDENTITY (1, 1) NOT NULL,
    [UserId]       INT              NOT NULL,
    [ActivityId]   UNIQUEIDENTIFIER NULL,
    [ActivityType] TINYINT          NOT NULL,
    [Data]         NVARCHAR (MAX)   NULL,
    [CreatedAt]    DATETIME         CONSTRAINT [DF_HistoryLog_CreatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_historyLog] PRIMARY KEY CLUSTERED ([Id] DESC)
);

