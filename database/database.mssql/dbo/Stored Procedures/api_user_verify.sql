
CREATE PROCEDURE [dbo].[api_user_verify]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@CellPhone VARCHAR(16),
	@Email VARCHAR(64),
	@VerificationCode VARCHAR(64)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @userId INT = NULL,	@userStatus TINYINT = NULL, @sessionStatus TINYINT = NULL, @verifyCode INT = NULL, @userPropDate DATETIME = NULL,
		@userCellPhone VARCHAR(16) = NULL, @userCellPhoneStatus TINYINT = NULL, @userEmail VARCHAR(64) = NULL, @userEmailStatus TINYINT = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userStatus = [Status] FROM dbo.[user] WITH(NOLOCK) WHERE Id = @userId
	IF(@userStatus <> 100)
		RETURN 410; -- User is not active

	SELECT @verifyCode = [Value], @userPropDate = [ModifiedAt] FROM dbo.userProperty WITH(NOLOCK) WHERE UserId = @userId AND PropTypeId = 5 -- 5: VerificationCode
	IF(@verifyCode IS NULL)
		RETURN 411; -- You must request for verification code first
	IF(DATEDIFF(MINUTE, GETDATE(), @userPropDate) > 10)
		RETURN 412; -- Your verification code has expired
	IF(@verifyCode <> @VerificationCode)
		RETURN 413; -- Verification code does not match

	IF(@CellPhone IS NOT NULL)
	BEGIN
		SELECT @userCellPhone = [Value], @userCellPhoneStatus = [Status] FROM dbo.userProperty WITH(NOLOCK) WHERE UserId = @userId AND PropTypeId = 2 -- 2: CellPhone
		IF(@userCellPhone IS NULL)
			RETURN 416; -- You must register a cell phone first
		IF(@userCellPhone <> @CellPhone)
			RETURN 417; -- CellPhone does not match
		IF(@userCellPhoneStatus = 100)
			RETURN 205; -- This cell phone is already active

		UPDATE dbo.userProperty SET [ModifiedAt] = GETDATE(), [Status] = 100 WHERE UserId = @userId AND [Value] = @CellPhone AND PropTypeId = 2 -- 2: CellPhone
	END

	IF(@Email IS NOT NULL)
	BEGIN
		SELECT @userEmail = [Value], @userEmailStatus = [Status] FROM dbo.userProperty WITH(NOLOCK) WHERE UserId = @userId AND PropTypeId = 3 -- 3: Email
		IF(@userEmail IS NULL)
			RETURN 418; -- You must register an email first
		IF(@userEmail <> @Email)
			RETURN 419; -- Email does not match
		IF(@userEmailStatus = 100)
			RETURN 210; -- This cell phone is already active

		UPDATE dbo.userProperty SET [ModifiedAt] = GETDATE(), [Status] = 100 WHERE UserId = @userId AND [Value] = @Email AND PropTypeId = 3 -- 3: Email
	END
  
	RETURN 200; -- Done!
END