
CREATE PROCEDURE [dbo].[api_historyLog_insert]
	@UserId INT,
	@ActivityType TINYINT,
	@ActivityId UNIQUEIDENTIFIER,
	@Data NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO dbo.historyLog ([UserId], [ActivityType], [ActivityId], [Data])
	VALUES (@UserId, @ActivityType, @ActivityId, @Data)
END