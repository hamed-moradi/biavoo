CREATE TABLE [dbo].[imageScale] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_ImageScale_CreatedAt] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ImageScale] PRIMARY KEY CLUSTERED ([Id] DESC)
);

