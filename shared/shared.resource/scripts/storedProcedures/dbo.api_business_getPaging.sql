IF(OBJECT_ID('dbo.[api_business_getPaging]', 'P') IS NOT NULL)
    DROP PROCEDURE dbo.[api_business_getPaging];
GO

/****** Object:  StoredProcedure [dbo].[api_business_getPaging]    Script Date: 5/2/2019 7:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[api_business_getPaging]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@Title NVARCHAR(128) = NULL,
	@Categories VARCHAR(128) = NULL,
	@PageSize INT = 10,
	@PageIndex INT = 1,
	@Order VARCHAR(4) = 'DESC',
	@OrderBy VARCHAR(32) = 'Id'
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userStatus TINYINT = NULL, @catIds ArrayList = NULL, @point GEOGRAPHY = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId;
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userStatus = [Status] FROM dbo.[user] WITH(NOLOCK) WHERE Id = @userId;
	IF(@userStatus <> 90 AND @userStatus <> 100)
		RETURN 410; -- User is not active

	IF(@Categories IS NOT NULL)
		SET @catIds = dbo.Split(@Categories);

	SELECT * FROM dbo.business AS bns WITH(NOLOCK)
	WHERE (@Title IS NULL OR Title LIKE '%'+@Title+'%')
		AND (@Categories IS NULL OR EXISTS(
			SELECT bnsCat.Id FROM dbo.business2Category AS bnsCat WITH(NOLOCK)
			INNER JOIN @catIds AS cats ON cats.Id = bnsCat.Id
			WHERE bnsCat.BusinessId = bns.Id))
	ORDER BY
		CASE WHEN @OrderBy = 'Id' AND @Order = 'ASC' THEN Id END ASC,
		CASE WHEN @OrderBy = 'Id' AND @Order = 'DESC' THEN Id END DESC
	
	RETURN 200;
END;
GO
