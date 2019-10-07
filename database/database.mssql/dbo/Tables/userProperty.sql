CREATE TABLE [dbo].[userProperty] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NOT NULL,
    [PropTypeId] BIT            NOT NULL,
    [Value]      NVARCHAR (MAX) NOT NULL,
    [CreatedAt]  DATETIME       CONSTRAINT [DF_UserProperty_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [ModifiedAt] DATETIME       CONSTRAINT [DF_UserProperty_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [Status]     TINYINT        CONSTRAINT [DF_UserProperty_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_UserProperty] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserProperty_PropertyType] FOREIGN KEY ([PropTypeId]) REFERENCES [dbo].[propertyType] ([Id]),
    CONSTRAINT [FK_UserProperty_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[user] ([Id])
);

