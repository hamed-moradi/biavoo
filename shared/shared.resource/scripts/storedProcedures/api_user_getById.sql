﻿IF OBJECT_ID('dbo.[api_user_getById]', 'P') IS NOT NULL
    DROP PROCEDURE dbo.[api_user_getById];
GO

/****** Object:  StoredProcedure [dbo].[api_user_signUp]    Script Date: 5/2/2019 7:46:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[api_user_getById]
	@Token varchar(32),
	@DeviceId varchar(128),
	@Id int,
	@StatusCode smallint
AS
BEGIN
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	IF(100 NOT IN (SELECT [Status] FROM dbo.[user] WHERE Id = @userId))
		RETURN 410; -- User is not active

	SELECT * FROM dbo.[user] WITH(NOLOCK) WHERE Id = @Id;
	SELECT * FROM dbo.[userProperty] WITH(NOLOCK) WHERE UserId = @Id;

	SET @StatusCode = 1;
	RETURN @StatusCode;
END;