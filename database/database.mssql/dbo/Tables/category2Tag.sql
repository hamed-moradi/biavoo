CREATE TABLE [dbo].[category2Tag] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [CategoryId] INT NOT NULL,
    [TagId]      INT NOT NULL,
    [Priority]   INT NOT NULL,
    CONSTRAINT [PK_Category2Tag] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Category2Tag_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[category] ([Id]),
    CONSTRAINT [FK_Category2Tag_Tag] FOREIGN KEY ([TagId]) REFERENCES [dbo].[tag] ([Id])
);

