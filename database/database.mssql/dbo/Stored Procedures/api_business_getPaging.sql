
CREATE PROCEDURE [dbo].[api_business_getPaging]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@CustomerId INT = NULL,
	@Title NVARCHAR(128) = NULL,
	@BusinessCode VARCHAR(16) = NULL,
	@Categories VARCHAR(128) = NULL,
	@Skip INT = 0,
	@Take INT = 10,
	@Order VARCHAR(4) = NULL,
	@OrderBy VARCHAR(32) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userStatus TINYINT = NULL, @catIds ArrayList;

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

	SELECT *, COUNT(1) OVER() AS TotalCount FROM dbo.business AS bns WITH(NOLOCK)
	WHERE ((@CustomerId IS NULL AND [CustomerId] = @userId) OR (@CustomerId IS NOT NULL AND [CustomerId] = @CustomerId))
		AND (@Title IS NULL OR Title LIKE '%'+@Title+'%')
		AND (@BusinessCode IS NULL OR BusinessCode LIKE '%'+@BusinessCode+'%')
		AND (@Categories IS NULL OR EXISTS(
			SELECT bnsCat.Id FROM dbo.business2Category AS bnsCat WITH(NOLOCK)
			INNER JOIN @catIds AS cats ON cats.Id = bnsCat.Id
			WHERE bnsCat.BusinessId = bns.Id))
	ORDER BY
		CASE WHEN @OrderBy = 'Id' AND @Order = 'ASC' THEN Id END ASC,
		CASE WHEN @OrderBy = 'Id' AND (@Order <> 'ASC' OR @Order IS NULL) THEN Id END DESC,
		CASE WHEN @OrderBy = 'Title' AND @Order = 'ASC' THEN Title END ASC,
		CASE WHEN @OrderBy = 'Title' AND (@Order <> 'ASC' OR @Order IS NULL) THEN Title END DESC,
		CASE WHEN @OrderBy = 'BusinessCode' AND @Order = 'ASC' THEN BusinessCode END ASC,
		CASE WHEN @OrderBy = 'BusinessCode' AND (@Order <> 'ASC' OR @Order IS NULL) THEN BusinessCode END DESC,
		CASE WHEN @OrderBy = 'CreatedAt' AND @Order = 'ASC' THEN CreatedAt END ASC,
		CASE WHEN @OrderBy = 'CreatedAt' AND (@Order <> 'ASC' OR @Order IS NULL) THEN CreatedAt END DESC,
		CASE WHEN @OrderBy = 'ModifiedAt' AND @Order = 'ASC' THEN ModifiedAt END ASC,
		CASE WHEN @OrderBy = 'ModifiedAt' AND (@Order <> 'ASC' OR @Order IS NULL) THEN ModifiedAt END DESC,
		CASE WHEN @OrderBy IS NULL THEN CURRENT_TIMESTAMP END
	OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;

	RETURN 200;
END;