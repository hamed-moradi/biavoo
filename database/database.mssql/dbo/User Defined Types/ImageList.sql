CREATE TYPE [dbo].[ImageList] AS TABLE (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [EntityId]    INT            NOT NULL,
    [ScaleId]     INT            NOT NULL,
    [Entity]      VARCHAR (32)   NOT NULL,
    [Name]        NVARCHAR (128) NOT NULL,
    [Extension]   NVARCHAR (8)   NOT NULL,
    [Path]        NVARCHAR (512) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [CreatedAt]   DATETIME       NOT NULL,
    [ModifiedAt]  DATETIME       NOT NULL,
    [Status]      TINYINT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC));

