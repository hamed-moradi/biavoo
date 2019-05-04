USE [biavoo]
GO
/****** Object:  Table [dbo].[category]    Script Date: 5/2/2019 7:46:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[Id] [int] IDENTITY(1111,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL,
	[CreatorId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdaterId] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[Priority] [int] NOT NULL,
	[ThumbImage] [nvarchar](500) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[category] ADD  CONSTRAINT [DF_Category_ThumbImage]  DEFAULT (' ') FOR [ThumbImage]
GO
EXEC sys.sp_addextendedproperty @name=N'AppSection', @value=N'Category$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'category'
GO
