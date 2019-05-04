USE [biavoo]
GO
/****** Object:  Table [dbo].[phoneVerification]    Script Date: 5/2/2019 7:46:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phoneVerification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ExpiredAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PhoneVerification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[phoneVerification]  WITH CHECK ADD  CONSTRAINT [FK_PhoneVerification_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[customer] ([AdminId])
GO
ALTER TABLE [dbo].[phoneVerification] CHECK CONSTRAINT [FK_PhoneVerification_User]
GO
EXEC sys.sp_addextendedproperty @name=N'PhoneVerification', @value=N'PhoneVerification$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'phoneVerification'
GO
