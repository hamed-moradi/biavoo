
CREATE PROCEDURE [dbo].[api_user_signUp]
	-- [user]
	@Name NVARCHAR(64),
	@Family NVARCHAR(64),
	@Nickname NVARCHAR(64) = NULL,
	-- [customer]
	@NationalCode VARCHAR(16) = NULL,
	@BirthDate DATETIME = NULL,
	-- [userProperty]
	@CellPhone VARCHAR(16) = NULL,
	@Email NVARCHAR(128) = NULL,
	@VerificationCode INT,
	-- [session]
	@TimeZone VARCHAR(16),
	@Language VARCHAR(8),
	@DeviceId VARCHAR(128),
	@IP VARCHAR(16),
	@OS VARCHAR(64),
	@Version VARCHAR(64),
	@DeviceName VARCHAR(64) = NULL,
	@Browser VARCHAR(64) = NULL,
	-- [output]
	@Token CHAR(32) OUT
AS
BEGIN
	SET NOCOUNT ON;

	IF(@CellPhone IS NULL AND @Email IS NULL)
		RETURN 420;

	-- CellPhone checking
	IF(@CellPhone IS NOT NULL AND EXISTS(SELECT 1 FROM [dbo].[userProperty] WITH(NOLOCK) WHERE PropTypeId = 2 AND [Value] = @CellPhone))
		RETURN 421;
    
	-- Email checking
	IF(@Email IS NOT NULL AND EXISTS(SELECT 1 FROM [dbo].[userProperty] WITH(NOLOCK) WHERE PropTypeId = 3 AND [Value] = @Email))
		RETURN 422;

	BEGIN TRAN userSignUp
	BEGIN
		BEGIN TRY
			DECLARE @userId INT;

			-- Create [user]
			INSERT INTO dbo.[user] ([Name], [Family], [Nickname], [Username]) VALUES (@Name, @Family, @Nickname, dbo.NewUsername());
			SET @userId = SCOPE_IDENTITY();
			
			-- Create [customer]
			IF(@NationalCode IS NOT NULL)
				INSERT INTO dbo.[customer] ([UserId], NationalCode, BirthDate) VALUES (@userId, @NationalCode, @BirthDate)

			-- Create [userProperty] (VerificationCode)
			INSERT INTO dbo.userProperty ([UserId], [PropTypeId], [Value]) VALUES (@userId, 5, @VerificationCode);

			IF(@CellPhone IS NOT NULL)
				-- Create [userProperty]
				INSERT INTO dbo.userProperty ([UserId], [PropTypeId], [Value]) VALUES (@userId, 2, @CellPhone); -- 2: CellPhone

			IF(@Email IS NOT NULL)
				-- Create [userProperty]
				INSERT INTO dbo.userProperty ([UserId], [PropTypeId], [Value]) VALUES (@userId, 3, @Email); -- 3: Email

			-- Create [session]
			SET @Token = REPLACE(NEWID(), '-', '');
			INSERT INTO dbo.session ([UserId], [Token], [DeviceId], [IP], [OS], [Version], [DeviceName], [Browser], [TimeZone], [Language])
			VALUES (@userId, @Token, @DeviceId, @IP, @OS, @Version, @DeviceName, @Browser, @TimeZone, @Language);

			COMMIT TRAN userSignUp;

			SELECT * FROM [dbo].[user] WITH(NOLOCK) WHERE Id = @userId;
			SELECT * FROM [dbo].[customer] WITH(NOLOCK) WHERE UserId = @userId;
			SELECT * FROM [dbo].[userProperty] WITH(NOLOCK) WHERE UserId = @userId
				AND ([Status] = 10 OR [Status] = 100) -- 10: Pendding, 100: Active
				AND PropTypeId IN (2, 3); -- 2: CellPhone, 3: Email
			RETURN 200;
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN userSignUp;
			RETURN 500;
		END CATCH
	END
END