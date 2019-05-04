USE [biavoo]
GO
/****** Object:  UserDefinedTableType [dbo].[Hierarchy]    Script Date: 5/2/2019 7:46:11 PM ******/
CREATE TYPE [dbo].[Hierarchy] AS TABLE(
	[element_id] [int] NOT NULL,
	[sequenceNo] [int] NULL,
	[parent_ID] [int] NULL,
	[Object_ID] [int] NULL,
	[NAME] [nvarchar](2000) NULL,
	[StringValue] [nvarchar](max) NOT NULL,
	[ValueType] [varchar](10) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[element_id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
