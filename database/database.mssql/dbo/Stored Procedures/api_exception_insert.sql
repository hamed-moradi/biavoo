
CREATE PROCEDURE [dbo].[api_exception_insert]
	@Data NVARCHAR(MAX),
	@Message NVARCHAR(MAX),
	@Source NVARCHAR(MAX),
	@StackTrace NVARCHAR(MAX),
	@TargetSite NVARCHAR(MAX) = NULL,
	@URL NVARCHAR(MAX),
	@IP NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO dbo.exception ([Data], [Message], [Source], StackTrace, TargetSite, [URL], [IP])
	VALUES (@Data, @Message, @Source, @StackTrace, @TargetSite, @URL, @IP)
END