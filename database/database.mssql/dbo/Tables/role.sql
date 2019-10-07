CREATE TABLE [dbo].[role] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (32)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_role_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_role_Status] DEFAULT ((2)) NOT NULL,
    CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'Roles', @value = N'Roles$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'role';

