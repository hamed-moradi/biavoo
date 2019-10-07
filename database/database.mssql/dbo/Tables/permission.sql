CREATE TABLE [dbo].[permission] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [RoleId]   INT NOT NULL,
    [ModuleId] INT NOT NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED ([Id] ASC)
);

