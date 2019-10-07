
CREATE PROCEDURE [dbo].[api_product_new]
	@Token char(32),
	@DeviceId varchar(128),
	@BusinessId INT,
	@CategoryId INT,
	@Title NVARCHAR(128),
	@Description NVARCHAR(MAX) = NULL,
	@Thumbnail NVARCHAR(512),
	@Images ImageList READONLY
AS
BEGIN
	DECLARE @userId INT = NULL, @sessionStatus TINYINT = NULL, @userStatus TINYINT = NULL, @productId INT = NULL;

	SELECT @userId = UserId, @sessionStatus = [Status] FROM dbo.[session] WITH(NOLOCK) WHERE Token = @Token AND DeviceId = @DeviceId;
	IF(@sessionStatus IS NULL)
		RETURN 400; -- Authentication failed
	IF(@sessionStatus <> 100)
		RETURN 405; -- Device is not active

	SELECT @userStatus = [Status] FROM dbo.[user] WHERE Id = @userId;
	IF(@userStatus <> 100)
		RETURN 410; -- User is not active

	BEGIN TRAN productNew;
	BEGIN
		BEGIN TRY
			-- Create product
			INSERT INTO dbo.[product] ([BusinessId], [CategoryId], [Title], [Description], [Thumbnail])
			VALUES (@BusinessId, @CategoryId, @Title, @Description, @Thumbnail)
			SET @productId = SCOPE_IDENTITY();

			-- Create product images
			IF(EXISTS(SELECT 1 FROM @Images))
			BEGIN
				INSERT INTO dbo.[image]([EntityId], [ScaleId], [Entity], [Name], [Extension], [Path], [Description])
				SELECT @productId, 1, 'product', [Name], [Extension], [Path], [Description] FROM @Images; -- 1: Product image
			END;
			SELECT * FROM dbo.image
			COMMIT TRAN productNew;

			SELECT * FROM dbo.[product] WHERE Id = @productId;
			SELECT * FROM dbo.[image] WHERE [Entity] = 'product' AND EntityId = @productId;
			RETURN 200; -- Done!
		END TRY
		BEGIN CATCH
			ROLLBACK TRAN productNew;
			RETURN 500;
		END CATCH
	END;
END;