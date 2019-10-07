CREATE TABLE [dbo].[tag] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [CreatedAt]   DATETIME       NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([Id] ASC)
);

