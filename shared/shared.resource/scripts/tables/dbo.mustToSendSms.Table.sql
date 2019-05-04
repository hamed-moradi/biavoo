USE [biavoo]
GO
/****** Object:  Table [dbo].[mustToSendSms]    Script Date: 5/2/2019 7:46:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mustToSendSms](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[MSISDN] [varchar](15) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[ShortCode] [varchar](15) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[AutoMessageUniqueKey] [varchar](64) NULL,
	[AutoMessageChannelKey] [varchar](32) NULL,
	[OverrideGateWay] [varchar](32) NULL,
 CONSTRAINT [PK_MustToSentSMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'پیام های متنی که قرار است برای کاربران ارسال می شود. - صف ارسال پیام های متنی' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'mustToSendSms'
GO
