IF(OBJECT_ID('dbo.[category]', 'U') IS NOT NULL)
    DROP TABLE dbo.[category];
GO

/****** Object:  Table [dbo].[category]    Script Date: 2019-10-05 14:12:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[category](
	[Id] [INT] IDENTITY(1,1) NOT NULL,
	[ParentId] [INT] NULL,
	[Title] [NVARCHAR](64) NOT NULL,
	[Description] [NVARCHAR](MAX) NULL,
	[CreatedAt] [DATETIME] NOT NULL,
	[Status] [TINYINT] NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[category] ADD  CONSTRAINT [DF_category_CreatedAt]  DEFAULT (GETDATE()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[category] ADD  CONSTRAINT [DF_category_Status]  DEFAULT ((10)) FOR [Status]
GO

ALTER TABLE [dbo].[category]  WITH CHECK ADD  CONSTRAINT [FK_category_category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[category] ([Id])
GO

ALTER TABLE [dbo].[category] CHECK CONSTRAINT [FK_category_category]
GO