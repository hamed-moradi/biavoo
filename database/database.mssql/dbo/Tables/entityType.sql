CREATE TABLE [dbo].[entityType] (
    [Id]    TINYINT       IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (64) NOT NULL,
    CONSTRAINT [PK_EntityType] PRIMARY KEY CLUSTERED ([Id] DESC)
);

