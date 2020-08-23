CREATE Trigger [dbo].[CTR_ProjectModification]
	On [dbo].[Project]
After Update
As
Begin
	Declare @ProjectId int = (select [Id] from inserted);
	Insert into [dbo].[Modification] ([projectId], [modificationDate])
		Values(@ProjectId, GETDATE());

End