CREATE Trigger [dbo].[CTR_OnValidPtoject]
On [dbo].[Project]
Instead Of Delete
As
Begin
	Update [dbo].[Project] Set [Active] = 1
		where [Id] in (select [Id] from deleted)
End