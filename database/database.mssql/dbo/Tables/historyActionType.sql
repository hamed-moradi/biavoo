CREATE TABLE [dbo].[historyActionType] (
    [Id]        TINYINT       IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (64) NOT NULL,
    [CreatedAt] DATETIME      CONSTRAINT [DF_HistoryActionType_CreatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_HistoryAction] PRIMARY KEY CLUSTERED ([Id] DESC)
);

