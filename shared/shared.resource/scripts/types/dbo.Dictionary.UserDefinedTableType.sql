USE [biavoo]
GO
/****** Object:  UserDefinedTableType [dbo].[Dictionary]    Script Date: 5/2/2019 7:46:11 PM ******/
CREATE TYPE [dbo].[Dictionary] AS TABLE(
	[ID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL
)
GO
