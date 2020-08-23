CREATE PROCEDURE [dbo].[CSP_GetProjectsByUser]
	@CreatorId int
As
Begin
	select * From [dbo].[V_ProjectCreator] AS PC
	Where PC.[CreatorId] = @CreatorId
	Return 1024;
End