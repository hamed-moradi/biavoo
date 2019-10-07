
CREATE PROCEDURE [dbo].[api_product_getByLocation]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@Title NVARCHAR(128) = NULL,
	@Categories VARCHAR(128) = NULL,
	@Latitude FLOAT,
	@Longitude FLOAT,
	@MakeItValid BIT = 0,
	@Radius INT = NULL
AS
BEGIN
	-- todo: get a limited number of products
	-- todo: get products by priority
	
	SET NOCOUNT ON;
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userStatus TINYINT = NULL, @catIds ArrayList, @point GEOGRAPHY = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId;
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userStatus = [Status] FROM dbo.[user] WITH(NOLOCK) WHERE Id = @userId;
	IF(@userStatus <> 90 AND @userStatus <> 100)
		RETURN 410; -- User is not active

	IF(@Categories IS NOT NULL)
	BEGIN
		INSERT INTO @catIds(Id)
		SELECT * FROM dbo.Split(@Categories, ',');
	END;

	IF(@Latitude IS NOT NULL AND @Longitude IS NOT NULL)
	BEGIN
		SET @point = geography::Point(@Latitude, @Longitude, 4326);
		IF(@point.STIsValid() <> 1)
			IF(@MakeItValid = 1)
				SET @point = @point.MakeValid();
			ELSE
				RETURN 411; -- Invalid point
	END;

	IF(@Radius IS NULL OR @Radius >= 500)
		SET @Radius = 25;

	SELECT * FROM dbo.product AS prd WITH(NOLOCK)
	INNER JOIN dbo.business AS bns WITH(NOLOCK)
		ON prd.BusinessId = bns.Id
	INNER JOIN dbo.category AS cat WITH(NOLOCK)
		ON prd.CategoryId = cat.Id
	WHERE (@Title IS NULL OR prd.Title LIKE '%'+@Title+'%')
		AND (@Categories IS NULL OR cat.Id IN (SELECT Item FROM dbo.Split(@Categories, ',')))
		AND (@Latitude IS NULL OR @Longitude IS NULL OR
			(@Latitude IS NOT NULL AND @Longitude IS NOT NULL AND @point.STDifference(bns.[Point]).ToString() <= @Radius))

	RETURN 200;
END;