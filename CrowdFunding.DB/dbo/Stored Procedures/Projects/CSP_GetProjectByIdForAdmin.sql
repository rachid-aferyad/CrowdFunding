CREATE PROCEDURE [dbo].[CSP_GetProjectByIdForAdmin]
	@ProjectId int
	As
Begin
	select * From [dbo].[V_ProjectAdmin] AS PA
	Where PA.[Id] = @ProjectId
	Return 1024;
End