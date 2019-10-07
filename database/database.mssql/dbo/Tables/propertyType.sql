CREATE TABLE [dbo].[propertyType] (
    [Id]          BIT            NOT NULL,
    [Title]       NVARCHAR (16)  NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PropertyType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

