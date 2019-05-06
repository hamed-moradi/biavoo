IF(OBJECT_ID('dbo.[exception]', 'P') IS NOT NULL)
    DROP TABLE dbo.[exception];
GO

/****** Object:  Table [dbo].[exception]    Script Date: 5/2/2019 7:46:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exception](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Source] [nvarchar](max) NOT NULL,
	[StackTrace] [nvarchar](max) NOT NULL,
	[TargetSite] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NOT NULL,
	[IP] [nvarchar](16) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Exception] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[exception] ADD  CONSTRAINT [DF_exception_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
