
CREATE PROCEDURE [dbo].[api_changeLog_insert]
	@AdminId INT,
	@ActionType TINYINT,
	@Entity VARCHAR(32),
	@EntityId BIGINT,
	@Data NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO dbo.changeLog ([AdminId], [ActionType], [Entity], [EntityId], [Data])
	VALUES (@AdminId, @ActionType, @Entity, @EntityId, @Data)
END