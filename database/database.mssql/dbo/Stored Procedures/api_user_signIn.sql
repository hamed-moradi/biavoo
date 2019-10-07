
CREATE PROCEDURE [dbo].[api_user_signIn]
	--@TimeZone VARCHAR(16),
	--@Language VARCHAR(8),
	@DeviceId NVARCHAR(128),
	@VerificationCode INT,
	@Password NVARCHAR(32) = NULL,
	@Token NVARCHAR(32) = NULL OUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userPass NVARCHAR(32) = NULL, @userStatus TINYINT = NULL, @verifyCode INT = NULL,
		@verifyCodeModifiedAt DATETIME = NULL, @sessionId INT = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE DeviceId = @DeviceId
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userPass = [Password], @userStatus = [Status] FROM dbo.[user] WHERE Id = @userId
	IF(@userStatus <> 100 AND @userStatus <> 90)
		RETURN 410; -- User is not active

	SELECT @sessionId = Id, @verifyCode = [Value], @verifyCodeModifiedAt = ModifiedAt FROM dbo.userProperty WITH(NOLOCK) WHERE UserId = @userId AND PropTypeId = 5 -- 5: Verification Code
	IF(@verifyCode IS NULL)
		RETURN 411; -- User must request for a verification code before signing in
	IF(DATEDIFF(MINUTE, @verifyCodeModifiedAt, GETDATE()) > 10) -- 10 minutes!
		RETURN 412; -- Your code has expired
	IF(@verifyCode <> @VerificationCode)
		RETURN 413; -- Verification code is not valid
	
	IF(@userPass IS NOT NULL)
	BEGIN
		IF(@Password IS NULL)
			RETURN 205;
		IF(@Password <> @userPass)
			RETURN 415;
	END;

	BEGIN TRAN userRefresh
	BEGIN
		BEGIN TRY
			-- Refresh user
			IF(@userStatus = 90)
			BEGIN
				UPDATE dbo.[user] SET [Status] = 100 WHERE Id = @userId;
				
				-- Refresh customer
				IF(EXISTS(SELECT 1 FROM dbo.[customer] WITH(NOLOCK) WHERE UserId = @userId AND [Status] = 90))
				BEGIN
					UPDATE dbo.[customer] SET [Status] = 100 WHERE UserId = @userId;
					-- If this user is a customer and it has businesses then it's businesses remain disabled
				END;
			END;

			-- Refresh token
			SET @Token = REPLACE(NEWID(), '-', '');
			UPDATE dbo.[session] SET [Token] = @Token WHERE Id = @sessionId;

			COMMIT TRAN userRefresh;
			RETURN 200;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN userRefresh;
			RETURN 500;
		END CATCH
	END;
END