
CREATE PROCEDURE [dbo].[api_comment_getPaging]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@EntityId INT,
	@Entity VARCHAR(32),
	@Keyword NVARCHAR(128) = NULL,
	@Skip INT = 0,
	@Take INT = 10,
	@Order VARCHAR(4) = NULL,
	@OrderBy VARCHAR(32) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userStatus TINYINT = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId;
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userStatus = [Status] FROM dbo.[user] WITH(NOLOCK) WHERE Id = @userId;
	IF(@userStatus <> 90 AND @userStatus <> 100)
		RETURN 410; -- User is not active

	SELECT * FROM dbo.[comment] WITH(NOLOCK)
	WHERE EntityId = @EntityId AND [Entity] = @Entity
		AND (@Keyword IS NULL OR [Body] LIKE '%' + @Keyword + '%')
	ORDER BY
		CASE WHEN @OrderBy = 'Id' AND @Order = 'ASC' THEN Id END ASC,
		CASE WHEN @OrderBy = 'Id' AND (@Order <> 'ASC' OR @Order IS NULL) THEN Id END DESC,
		CASE WHEN @OrderBy = 'CreatedAt' AND @Order = 'ASC' THEN CreatedAt END ASC,
		CASE WHEN @OrderBy = 'CreatedAt' AND (@Order <> 'ASC' OR @Order IS NULL) THEN CreatedAt END DESC,
		CASE WHEN @OrderBy = 'ModifiedAt' AND @Order = 'ASC' THEN ModifiedAt END ASC,
		CASE WHEN @OrderBy = 'ModifiedAt' AND (@Order <> 'ASC' OR @Order IS NULL) THEN ModifiedAt END DESC,
		CASE WHEN @OrderBy IS NULL THEN CURRENT_TIMESTAMP END
	OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;

	RETURN 200;
END;