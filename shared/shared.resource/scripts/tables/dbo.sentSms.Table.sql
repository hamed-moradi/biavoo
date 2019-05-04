USE [biavoo]
GO
/****** Object:  Table [dbo].[sentSms]    Script Date: 5/2/2019 7:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sentSms](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Getway] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[MSISDN] [varchar](15) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[TraceID] [int] NULL,
	[ShortCode] [varchar](25) NULL,
	[Status] [tinyint] NULL,
	[Correlator] [bigint] NULL,
	[ResponseStatusCode] [int] NULL,
	[ResponseStatusDescription] [nvarchar](max) NULL,
	[ResponseBody] [nvarchar](max) NULL,
	[AutoMessageUniqueKey] [varchar](64) NULL,
	[AutoMessageChannelKey] [varchar](32) NULL,
 CONSTRAINT [PK_SentSMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[sentSms] ADD  CONSTRAINT [DF_SentSMS_ShortCode]  DEFAULT ((98307399)) FOR [ShortCode]
GO
