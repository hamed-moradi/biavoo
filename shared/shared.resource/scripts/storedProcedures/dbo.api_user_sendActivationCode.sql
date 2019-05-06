IF(OBJECT_ID('dbo.[api_user_sendVerificationCode]', 'P') IS NOT NULL)
    DROP PROCEDURE dbo.[api_user_sendVerificationCode];
GO

/****** Object:  StoredProcedure [dbo].[api_user_sendVerificationCode]    Script Date: 5/2/2019 7:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[api_user_sendVerificationCode]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@CellPhone VARCHAR(16)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @userId INT = NULL,	@userStatus TINYINT = NULL, @userCellPhone VARCHAR(16) = NULL, @userCellPhoneStatus TINYINT = NULL

	SELECT @userId = UserId, @userStatus = [Status]
	FROM dbo.[session] WITH(NOLOCK)
	WHERE (Token = @Token) AND (DeviceId = @DeviceId)

	IF (@userId IS NULL)
		RETURN 400; -- session not found

	IF (@userStatus = 100)
		RETURN 205; -- user is already active

  IF (@userStatus <> 10)
		RETURN 405; -- user is not in the pendding state

  SELECT @userCellPhone = [Value], @userCellPhoneStatus = [Status] FROM dbo.userProperty
    WHERE UserId = @userId AND [Value] = @CellPhone AND PropTypeId = 2 -- CellPhone
	
  IF(@userCellPhone IS NULL)
    RETURN 410; -- requested cell phone number didn't find

  IF(@userCellPhoneStatus = 100)
    RETURN 210; -- user cell phone is already active

  IF(@userCellPhoneStatus <> 10)
    RETURN 415 -- user cell phone is not in the pendding state 
  
  RETURN 200; -- this user cell phone is ready to get active
END
GO
