CREATE TABLE [dbo].[category] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ParentId]    INT            NULL,
    [Title]       NVARCHAR (64)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_category_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_category_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_category_category] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[category] ([Id])
);

