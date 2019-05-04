USE [biavoo]
GO
/****** Object:  Table [dbo].[moduleReference]    Script Date: 5/2/2019 7:46:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[moduleReference](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Title] [nvarchar](64) NOT NULL,
	[Path] [nvarchar](512) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Icon] [nvarchar](512) NULL,
	[HttpMethod] [varchar](16) NOT NULL,
	[Category] [tinyint] NOT NULL,
	[Priority] [tinyint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo.SystemModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[moduleReference] ADD  CONSTRAINT [DF__SystemMod__HttpM__0880433F]  DEFAULT ('') FOR [HttpMethod]
GO
ALTER TABLE [dbo].[moduleReference] ADD  CONSTRAINT [DF__SystemMod__Prior__09746778]  DEFAULT ((0)) FOR [Priority]
GO
ALTER TABLE [dbo].[moduleReference] ADD  CONSTRAINT [DF_SystemModules_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[moduleReference] ADD  CONSTRAINT [DF_moduleReference_Status]  DEFAULT ((2)) FOR [Status]
GO
ALTER TABLE [dbo].[moduleReference]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SystemModules_dbo.SystemModules_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[moduleReference] ([Id])
GO
ALTER TABLE [dbo].[moduleReference] CHECK CONSTRAINT [FK_dbo.SystemModules_dbo.SystemModules_ParentId]
GO
