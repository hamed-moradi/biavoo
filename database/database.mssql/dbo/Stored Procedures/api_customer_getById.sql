
CREATE PROCEDURE [dbo].[api_customer_getById]
	@Token VARCHAR(32),
	@DeviceId VARCHAR(128),
	@Id INT
AS
BEGIN
  SET NOCOUNT ON;

  SELECT * FROM dbo.customer WITH(NOLOCK) WHERE UserId = @Id
END