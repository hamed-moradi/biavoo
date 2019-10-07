CREATE TABLE [dbo].[exception] (
    [Id]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [CreatedAt]  DATETIME        CONSTRAINT [DF_exception_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [URL]        NVARCHAR (1024) NOT NULL,
    [Data]       NVARCHAR (MAX)  NOT NULL,
    [Message]    NVARCHAR (MAX)  NOT NULL,
    [Source]     NVARCHAR (MAX)  NOT NULL,
    [StackTrace] NVARCHAR (MAX)  NOT NULL,
    [TargetSite] NVARCHAR (MAX)  NULL,
    [IP]         NVARCHAR (16)   NOT NULL,
    CONSTRAINT [PK_Exception] PRIMARY KEY CLUSTERED ([Id] ASC)
);

