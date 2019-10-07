CREATE TABLE [dbo].[userPrivacy] (
    [Id]                INT      IDENTITY (1, 1) NOT NULL,
    [UserId]            INT      NOT NULL,
    [AppearingInSearch] BIT      NOT NULL,
    [ModifiedAt]        DATETIME CONSTRAINT [DF_UserPrivacy_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [CreatedAt]         DATETIME CONSTRAINT [DF_UserPrivacy_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]            TINYINT  CONSTRAINT [DF_UserPrivacy_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_UserPrivacy] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserPrivacy_PrivacyType] FOREIGN KEY ([AppearingInSearch]) REFERENCES [dbo].[propertyType] ([Id]),
    CONSTRAINT [FK_UserPrivacy_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[user] ([Id])
);

