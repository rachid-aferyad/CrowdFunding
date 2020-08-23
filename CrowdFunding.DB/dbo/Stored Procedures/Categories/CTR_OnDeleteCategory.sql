CREATE Trigger [dbo].[CTR_OnDeleteCategory]
	On [dbo].[Category]
Instead Of Delete
As
Begin
	Delete From [dbo].[CategoriesProjects]
		Where [CategoryId] in (select [CategoryId] from deleted)
End