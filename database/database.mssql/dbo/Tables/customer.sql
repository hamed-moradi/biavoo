CREATE TABLE [dbo].[customer] (
    [UserId]       INT          IDENTITY (1, 1) NOT NULL,
    [NationalCode] VARCHAR (16) NULL,
    [BirthDate]    DATETIME     NULL,
    [CreatedAt]    DATETIME     CONSTRAINT [DF_customer_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [Status]       TINYINT      CONSTRAINT [DF_customer_Status] DEFAULT ((10)) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([UserId] DESC),
    CONSTRAINT [IX_User_UserId] UNIQUE NONCLUSTERED ([UserId] ASC)
);

