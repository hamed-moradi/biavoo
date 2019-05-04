USE [biavoo]
GO
/****** Object:  Table [dbo].[comment]    Script Date: 5/2/2019 7:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comment](
	[Id] [int] IDENTITY(111,1) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[IP] [nvarchar](64) NOT NULL,
	[ReplyTo] [int] NULL,
	[DeveloperId] [int] NULL,
	[AdminId] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[Status] [tinyint] NOT NULL,
	[UpdaterId] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Comment] FOREIGN KEY([ReplyTo])
REFERENCES [dbo].[comment] ([Id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_Comment_Comment]
GO
ALTER TABLE [dbo].[comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Developer] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[user] ([Id])
GO
ALTER TABLE [dbo].[comment] CHECK CONSTRAINT [FK_Comment_Developer]
GO
EXEC sys.sp_addextendedproperty @name=N'AppSection', @value=N'Comment$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'comment'
GO
