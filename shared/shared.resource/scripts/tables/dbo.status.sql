IF(OBJECT_ID('dbo.[status]', 'P') IS NOT NULL)
    DROP TABLE dbo.[status];
GO

/****** Object:  Table [dbo].[status]    Script Date: 5/2/2019 7:46:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[Id] [tinyint] NOT NULL,
	[Title] [nvarchar](16) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
