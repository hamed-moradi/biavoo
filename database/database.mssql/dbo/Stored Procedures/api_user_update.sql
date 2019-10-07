
CREATE PROCEDURE [dbo].[api_user_update]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@AppearingInSearch BIT
AS
BEGIN
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userStatus TINYINT = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId;
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userStatus = [Status] FROM dbo.[user] WHERE Id = @userId;
	IF(@userStatus <> 100)
		RETURN 410; -- User is not active

	UPDATE dbo.[userPrivacy] SET [AppearingInSearch] = @AppearingInSearch, ModifiedAt = GETDATE() WHERE Id = @userId;
	RETURN 200; -- Done!
END;