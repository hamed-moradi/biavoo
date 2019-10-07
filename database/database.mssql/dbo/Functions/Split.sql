
Create FUNCTION [dbo].[Split] (@String VARCHAR(MAX), @Delimiter CHAR(1) = NULL)
RETURNS
	@ReturnList TABLE ([Item] NVARCHAR(MAX) NULL)
AS
BEGIN
	DECLARE @name NVARCHAR(MAX), @pos INT;
	IF(@Delimiter IS NULL)
		SET @Delimiter = ',';

	WHILE CHARINDEX(@Delimiter, @String) > 0
	BEGIN
		SELECT @pos  = CHARINDEX(@Delimiter, @String);
		SELECT @name = SUBSTRING(@String, 1, @pos-1);

		INSERT INTO @ReturnList SELECT @name;

		SELECT @String = SUBSTRING(@String, @pos+1, LEN(@String)-@pos);
	END

	INSERT INTO @ReturnList SELECT @String;

	RETURN;
END