CREATE PROCEDURE [dbo].[CSP_DeleteProject]
	@ProjectId int
AS
	Delete From [dbo].[Project]
		Where [Id] = @ProjectId
RETURN 0