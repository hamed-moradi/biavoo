CREATE TABLE [dbo].[gender] (
    [Id]          TINYINT        NOT NULL,
    [Title]       NVARCHAR (16)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_gender] PRIMARY KEY CLUSTERED ([Id] ASC)
);

