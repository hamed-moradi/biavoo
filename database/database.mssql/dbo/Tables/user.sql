CREATE TABLE [dbo].[user] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (64)  NOT NULL,
    [Family]     NVARCHAR (64)  NOT NULL,
    [Nickname]   NVARCHAR (64)  NULL,
    [Username]   VARCHAR (16)   NOT NULL,
    [Password]   VARCHAR (32)   NULL,
    [Avatar]     NVARCHAR (512) NULL,
    [ModifiedAt] DATETIME       CONSTRAINT [DF__user__ModifiedAt__69279377] DEFAULT (getdate()) NOT NULL,
    [CreatedAt]  DATETIME       CONSTRAINT [DF_user_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]     TINYINT        CONSTRAINT [DF_user_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'Developer$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'user';

