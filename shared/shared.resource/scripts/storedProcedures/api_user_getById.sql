IF OBJECT_ID('dbo.[api_user_getById]', 'P') IS NOT NULL
    DROP PROCEDURE dbo.[api_user_getById];
GO

CREATE PROCEDURE [dbo].[api_user_getById]
	@Token varchar(32),
	@DeviceId varchar(128),
	@Id int,
	@StatusCode smallint
AS
BEGIN
	IF(NOT EXISTS(SELECT 1 FROM dbo.[session] WHERE Token = @Token AND DeviceId = @DeviceId))
	BEGIN
		SET @StatusCode = 400; -- Authentication failed
		RETURN @StatusCode;
	END;

	SELECT * FROM dbo.[user] WHERE Id = @Id;
	SELECT * FROM dbo.[userProperty] WHERE UserId = @Id;

	SET @StatusCode = 1;
	RETURN @StatusCode;
END;