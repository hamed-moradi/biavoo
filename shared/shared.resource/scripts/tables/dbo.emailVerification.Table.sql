USE [biavoo]
GO
/****** Object:  Table [dbo].[emailVerification]    Script Date: 5/2/2019 7:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emailVerification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ExpiredAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmailVerification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[emailVerification]  WITH CHECK ADD  CONSTRAINT [FK_EmailVerification_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[customer] ([AdminId])
GO
ALTER TABLE [dbo].[emailVerification] CHECK CONSTRAINT [FK_EmailVerification_User]
GO
EXEC sys.sp_addextendedproperty @name=N'AppSection', @value=N'EmailVerification$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'emailVerification'
GO
