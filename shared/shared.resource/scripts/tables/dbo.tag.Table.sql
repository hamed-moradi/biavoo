USE [biavoo]
GO
/****** Object:  Table [dbo].[tag]    Script Date: 5/2/2019 7:46:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tag](
	[Id] [int] IDENTITY(1111,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Priority] [int] NOT NULL,
	[CreatorId] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdaterId] [int] NULL,
	[UpdatedAt] [datetime] NULL,
	[Status] [tinyint] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsFirstPage] [bit] NOT NULL,
	[IsFirstPageSlider] [bit] NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tag] ADD  CONSTRAINT [DF_Tag_IsDeletable]  DEFAULT ((1)) FOR [IsDeletable]
GO
ALTER TABLE [dbo].[tag] ADD  CONSTRAINT [DF_Tag_IsFirstPage]  DEFAULT ((0)) FOR [IsFirstPage]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'قابلیت پاک شدن تگ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tag', @level2type=N'COLUMN',@level2name=N'IsDeletable'
GO
EXEC sys.sp_addextendedproperty @name=N'AppSection', @value=N'Tag$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tag'
GO
