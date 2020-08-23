CREATE PROCEDURE [dbo].[CSP_DeleteCategory]
	@Id int
AS
	Delete From [dbo].[Category]
		Where [Id] = @Id;
RETURN 0