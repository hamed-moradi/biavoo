CREATE TABLE [dbo].[setting] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Key]   NVARCHAR (50)  NOT NULL,
    [Value] NVARCHAR (MAX) NOT NULL,
    [Name]  NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Setting$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'setting';

