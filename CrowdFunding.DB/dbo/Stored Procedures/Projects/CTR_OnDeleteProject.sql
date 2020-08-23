CREATE Trigger [dbo].[CTR_OnDeleteProject]
	On [dbo].[Project]
After Delete
As
Begin
	
	Update [dbo].[Project] Set [Active] = 0
		where [Id] in (select [Id] from deleted)

	--Delete From [dbo].[CategoriesProjects]
		--Where [projectId] in (select Id from deleted)
End