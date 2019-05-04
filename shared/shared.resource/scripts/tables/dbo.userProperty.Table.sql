USE [biavoo]
GO
/****** Object:  Table [dbo].[userProperty]    Script Date: 5/2/2019 7:46:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PropTypeId] [tinyint] NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_CustomerProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[userProperty] ADD  CONSTRAINT [DF_CustomerProperty_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[userProperty] ADD  CONSTRAINT [DF_CustomerProperty_Status]  DEFAULT ((10)) FOR [Status]
GO
ALTER TABLE [dbo].[userProperty]  WITH CHECK ADD  CONSTRAINT [FK_CustomerProperty_PropertyType] FOREIGN KEY([PropTypeId])
REFERENCES [dbo].[propertyType] ([Id])
GO
ALTER TABLE [dbo].[userProperty] CHECK CONSTRAINT [FK_CustomerProperty_PropertyType]
GO
ALTER TABLE [dbo].[userProperty]  WITH CHECK ADD  CONSTRAINT [FK_UserProperty_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[user] ([Id])
GO
ALTER TABLE [dbo].[userProperty] CHECK CONSTRAINT [FK_UserProperty_User]
GO
