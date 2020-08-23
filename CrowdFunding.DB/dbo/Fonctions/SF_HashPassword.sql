CREATE FUNCTION [dbo].[SF_HashPassword]
    (
	    @Password VARCHAR(20),
        @Salt VARCHAR(255)
    )
RETURNS VARBINARY(64)
AS
BEGIN
    RETURN HASHBYTES('SHA2_512', CONCAT( @Password, @Salt))
END