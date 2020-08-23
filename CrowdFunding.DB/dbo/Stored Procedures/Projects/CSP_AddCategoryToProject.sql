CREATE PROCEDURE [dbo].[CSPAddCategoryToProject]
	@categoryId int,
	@projectId int
AS
	Insert into [dbo].[CategoriesProjects] ([categoryId], [projectId])
	Values (@categoryId, @projectId)
RETURN 0
