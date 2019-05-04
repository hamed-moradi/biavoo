USE [biavoo]
GO
/****** Object:  Table [dbo].[historyActionType]    Script Date: 5/2/2019 7:46:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historyActionType](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](64) NOT NULL,
 CONSTRAINT [PK_HistoryAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
