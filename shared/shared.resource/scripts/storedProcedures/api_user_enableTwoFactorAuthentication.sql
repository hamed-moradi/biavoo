IF OBJECT_ID('dbo.[api_user_enableTwoFactorAuthentication]', 'P') IS NOT NULL
    DROP PROCEDURE dbo.[api_user_enableTwoFactorAuthentication];
GO

CREATE PROCEDURE [dbo].[api_user_enableTwoFactorAuthentication]
	@Token varchar(32),
	@DeviceId varchar(128),
	@VerificationCode int,
	@Password NVARCHAR(32)
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