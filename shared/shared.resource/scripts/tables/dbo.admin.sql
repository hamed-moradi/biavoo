IF(OBJECT_ID('dbo.[admin]', 'P') IS NOT NULL)
    DROP TABLE dbo.[admin];
GO

/****** Object:  Table [dbo].[admin]    Script Date: 5/2/2019 7:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[Id] [nvarchar](512) NOT NULL,
	[Username] [nvarchar](32) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Name] [nvarchar](32) NULL,
	[Family] [nvarchar](32) NULL,
	[Cellphone] [nvarchar](16) NOT NULL,
	[Email] [nvarchar](64) NULL,
	[Gender] [tinyint] NULL,
	[Avatar] [nvarchar](512) NULL,
	[RoleId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [IX_Admin] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin] ADD  CONSTRAINT [DF_admin_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[admin] ADD  CONSTRAINT [DF_admin_Status]  DEFAULT ((2)) FOR [Status]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_gender] FOREIGN KEY([Gender])
REFERENCES [dbo].[gender] ([Id])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_admin_gender]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_Admin_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[role] ([Id])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_Admin_Role]
GO
