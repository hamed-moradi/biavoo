CREATE TABLE [dbo].[sentMessage] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [TypeId]     TINYINT        NOT NULL,
    [CategoryId] TINYINT        NOT NULL,
    [CellPhone]  VARCHAR (16)   NULL,
    [Email]      VARCHAR (64)   NULL,
    [Subject]    NVARCHAR (512) NULL,
    [Body]       NVARCHAR (MAX) NOT NULL,
    [Gateway]    VARCHAR (32)   NOT NULL,
    [CreatedAt]  DATETIME       DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_sentMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'پیام های ارسال شده', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'sentMessage';

