
CREATE FUNCTION [dbo].[NewUsername]()
	RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @number VARCHAR(10) = NULL;
    WHILE (1 = 1)
    BEGIN
        SELECT @number = Id FROM dbo.RandomNumber WITH(NOLOCK);
        IF (LEN(@number) <> 10) CONTINUE;
        IF (EXISTS (SELECT * FROM dbo.[user] WITH(NOLOCK) WHERE Username = @number)) CONTINUE;
        RETURN @number;
    END;
    RETURN @number;
END;