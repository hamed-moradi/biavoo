IF(OBJECT_ID('dbo.[RandomNumber]', 'P') IS NOT NULL)
    DROP VIEW dbo.[RandomNumber];
GO

/****** Object:  View [dbo].[RandomNumber]    Script Date: 5/2/2019 7:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RandomNumber] AS SELECT ABS(CHECKSUM(NEWID())) AS Id
GO
