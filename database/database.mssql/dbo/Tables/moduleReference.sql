CREATE TABLE [dbo].[moduleReference] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ParentId]    INT            NULL,
    [Title]       NVARCHAR (64)  NOT NULL,
    [Path]        NVARCHAR (512) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Icon]        NVARCHAR (32)  NULL,
    [HttpMethod]  NVARCHAR (16)  CONSTRAINT [DF__SystemMod__HttpM__0880433F] DEFAULT ('') NOT NULL,
    [Category]    TINYINT        NOT NULL,
    [Priority]    TINYINT        CONSTRAINT [DF__SystemMod__Prior__09746778] DEFAULT ((0)) NOT NULL,
    [CreatedAt]   DATETIME       CONSTRAINT [DF_SystemModules_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]      TINYINT        CONSTRAINT [DF_moduleReference_Status] DEFAULT ((2)) NOT NULL,
    CONSTRAINT [PK_moduleReference] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_moduleReference_moduleReference_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[moduleReference] ([Id])
);

