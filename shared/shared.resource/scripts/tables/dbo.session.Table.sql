USE [biavoo]
GO
/****** Object:  Table [dbo].[session]    Script Date: 5/2/2019 7:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[session](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Token] [char](32) NOT NULL,
	[DeviceId] [varchar](128) NOT NULL,
	[IP] [varchar](64) NOT NULL,
	[OS] [varchar](128) NULL,
	[Version] [varchar](128) NULL,
	[DeviceName] [varchar](128) NULL,
	[Browser] [varchar](128) NULL,
	[TimeZone] [varchar](16) NULL,
	[Language] [varchar](8) NULL,
	[FCM] [varchar](max) NULL,
	[ModifiedAt] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [smallint] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[session] ADD  CONSTRAINT [DF_session_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[session]  WITH CHECK ADD  CONSTRAINT [FK_Session_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[user] ([Id])
GO
ALTER TABLE [dbo].[session] CHECK CONSTRAINT [FK_Session_User]
GO
EXEC sys.sp_addextendedproperty @name=N'AppSection', @value=N'Session$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'session'
GO
