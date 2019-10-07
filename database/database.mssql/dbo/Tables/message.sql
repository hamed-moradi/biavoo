CREATE TABLE [dbo].[message] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)  NULL,
    [Title]          NVARCHAR (150) NULL,
    [Email]          NVARCHAR (50)  NULL,
    [CellPhone]      VARCHAR (15)   NULL,
    [Body]           NVARCHAR (MAX) NOT NULL,
    [IsImportant]    BIT            CONSTRAINT [DF_Message_IsImportant] DEFAULT ((0)) NOT NULL,
    [UserId]         INT            NULL,
    [LastSeenUserId] INT            NULL,
    [LastSeenAt]     DATETIME       CONSTRAINT [DF_Message_LastSeenDate] DEFAULT (getdate()) NULL,
    [CreatedAt]      DATETIME       CONSTRAINT [DF_Message_CreateDate] DEFAULT (getdate()) NOT NULL,
    [Status]         TINYINT        NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([Id] ASC)
);

