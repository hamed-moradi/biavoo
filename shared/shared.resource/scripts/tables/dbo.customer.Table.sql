USE [biavoo]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 5/2/2019 7:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[AdminId] [int] IDENTITY(1111,1) NOT NULL,
	[Username] [varchar](32) NOT NULL,
	[Password] [nvarchar](32) NULL,
	[Name] [nvarchar](32) NULL,
	[Family] [nvarchar](32) NULL,
	[Avatar] [nvarchar](512) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[RequiresTwoFactor] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_User_Username] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [DF_customer_Status]  DEFAULT ((2)) FOR [Status]
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ((0)) FOR [RequiresTwoFactor]
GO
EXEC sys.sp_addextendedproperty @name=N'AppSection', @value=N'User$$$list|add|delete|edit|filter|print|excel|details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'customer'
GO
