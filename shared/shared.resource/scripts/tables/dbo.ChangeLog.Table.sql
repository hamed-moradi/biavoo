USE [biavoo]
GO
/****** Object:  Table [dbo].[ChangeLog]    Script Date: 5/2/2019 7:46:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdminId] [int] NOT NULL,
	[ActionType] [tinyint] NOT NULL,
	[Entity] [varchar](32) NOT NULL,
	[EntityId] [bigint] NOT NULL,
	[Data] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_ChangeLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChangeLog] ADD  CONSTRAINT [DF_ChangeLog_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
