CREATE TABLE [dbo].[page] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UniqueName]  VARCHAR (50)   NOT NULL,
    [Title]       NVARCHAR (256) NOT NULL,
    [UpTitle]     NVARCHAR (256) CONSTRAINT [DF_Page_UpTitle] DEFAULT ('') NOT NULL,
    [SubTitle]    NVARCHAR (256) CONSTRAINT [DF_Page_SubTitle] DEFAULT ('') NOT NULL,
    [Summary]     NVARCHAR (MAX) CONSTRAINT [DF_Page_Summary] DEFAULT ('') NOT NULL,
    [Body]        NVARCHAR (MAX) NOT NULL,
    [ThumbImage]  NVARCHAR (500) NOT NULL,
    [BannerImage] NVARCHAR (500) NOT NULL,
    [CreatorId]   INT            NOT NULL,
    [CreatedAt]   DATETIME       NOT NULL,
    [UpdaterId]   INT            NULL,
    [UpdatedAt]   DATETIME       NULL,
    [Status]      TINYINT        NOT NULL,
    CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [IX_Page] UNIQUE NONCLUSTERED ([UniqueName] ASC)
);

