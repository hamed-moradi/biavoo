IF(OBJECT_ID('dbo.[api_business_get]', 'P') IS NOT NULL)
    DROP PROCEDURE dbo.[api_business_get];
GO

/****** Object:  StoredProcedure [dbo].[api_business_get]    Script Date: 5/2/2019 7:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[api_business_get]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@Title NVARCHAR(128) = NULL,
	@Categories VARCHAR(128) = NULL,
	@Latitude FLOAT = NULL,
	@Longitude FLOAT = NULL,
	@Radius INT = NULL
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

	IF(@Latitude IS NOT NULL AND @Longitude IS NOT NULL)
		SET @point = geography::Point(@Latitude, @Longitude, 4326);

	IF(@Radius IS NULL OR @Radius >= 500)
		SET @Radius = 25;

	SELECT * FROM dbo.business AS bns WITH(NOLOCK)
	WHERE (@Title IS NULL OR Title LIKE '%'+@Title+'%')
		AND (@Categories IS NULL OR EXISTS(
			SELECT bnsCat.Id FROM dbo.business2Category AS bnsCat WITH(NOLOCK)
			INNER JOIN @catIds AS cats ON cats.Id = bnsCat.Id
			WHERE bnsCat.BusinessId = bns.Id))
		AND (@Latitude IS NULL OR @Longitude IS NULL OR 
			(@Latitude IS NOT NULL AND @Longitude IS NOT NULL AND @point.STDifference(bns.[Point]) <= @Radius))

	RETURN 200;
END;
GO
