CREATE PROCEDURE [dbo].[CSP_AddCategoryToProject]
	@CategoryId int,
	@ProjectId int
AS
	Insert into [dbo].[CategoriesProjects] ([CategoryId], [ProjectId])
	Values (@CategoryId, @ProjectId)
RETURN 0