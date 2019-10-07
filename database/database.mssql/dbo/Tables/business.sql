CREATE TABLE [dbo].[business] (
    [Id]           INT               IDENTITY (1, 1) NOT NULL,
    [CustomerId]   INT               NOT NULL,
    [Title]        NVARCHAR (64)     NOT NULL,
    [Description]  NVARCHAR (MAX)    NULL,
    [Phone]        VARCHAR (64)      NULL,
    [Address]      NVARCHAR (64)     NULL,
    [BusinessCode] VARCHAR (16)      NULL,
    [Thumbnail]    NVARCHAR (512)    NULL,
    [Latitude]     FLOAT (53)        NOT NULL,
    [Longitude]    FLOAT (53)        NOT NULL,
    [Point]        [sys].[geography] NOT NULL,
    [CreatedAt]    DATETIME          CONSTRAINT [DF_business_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [ModifiedAt]   DATETIME          CONSTRAINT [DF_business_ModifiedAt] DEFAULT (getdate()) NOT NULL,
    [Status]       TINYINT           CONSTRAINT [DF_business_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_Business] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'AppSection', @value = N'User$$$list|add|delete|edit|filter|print|excel|details', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'business';

