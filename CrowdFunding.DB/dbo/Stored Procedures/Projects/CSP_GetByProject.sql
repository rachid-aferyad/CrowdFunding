CREATE PROCEDURE [dbo].[CSP_GetByProject]
	@Table nvarchar(255),
	@ProjectId varchar(255)
AS
	DECLARE @sql NVARCHAR(64)

	SET @sql = 'SELECT * FROM [dbo].' + QUOTENAME(@table) + ' Where [ProjectId] = ' + @ProjectId
 
	EXEC (@sql)
RETURN 0
