CREATE TABLE [dbo].[messageCategory] (
    [Id]          TINYINT        IDENTITY (1, 1) NOT NULL,
    [Title]       VARCHAR (32)   NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_MessageCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'دسته بندی پیام ها', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'messageCategory';

