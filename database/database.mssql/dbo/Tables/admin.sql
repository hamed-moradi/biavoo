CREATE TABLE [dbo].[admin] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]       INT            NOT NULL,
    [Username]     NVARCHAR (32)  NOT NULL,
    [Password]     NVARCHAR (32)  NOT NULL,
    [Name]         NVARCHAR (32)  NULL,
    [Family]       NVARCHAR (32)  NULL,
    [Cellphone]    NVARCHAR (16)  NOT NULL,
    [Email]        VARCHAR (64)   NULL,
    [Gender]       TINYINT        NULL,
    [Avatar]       NVARCHAR (512) NULL,
    [LastSignedin] DATETIME       NULL,
    [CreatedAt]    DATETIME       CONSTRAINT [DF_admin_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]       TINYINT        CONSTRAINT [DF_admin_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_admin_gender] FOREIGN KEY ([Gender]) REFERENCES [dbo].[gender] ([Id]),
    CONSTRAINT [FK_ddmin_role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[role] ([Id]),
    CONSTRAINT [IX_admin] UNIQUE NONCLUSTERED ([Id] DESC)
);

