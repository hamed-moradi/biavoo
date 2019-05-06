IF(OBJECT_ID('dbo.[admin]', 'P') IS NOT NULL)
    DROP TABLE dbo.[admin];
GO

/****** Object:  Table [dbo].[mustToSendEmail]    Script Date: 5/2/2019 7:46:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mustToSendEmail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Recipient] [nvarchar](64) NOT NULL,
	[Subject] [nvarchar](256) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[AutoMessageUniqueKey] [varchar](64) NULL,
	[AutoMessageChannelKey] [varchar](32) NULL,
 CONSTRAINT [PK_MustToSendEmail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
