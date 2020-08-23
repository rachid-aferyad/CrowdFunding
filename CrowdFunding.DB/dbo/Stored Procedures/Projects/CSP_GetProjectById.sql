CREATE PROCEDURE [dbo].[CSP_GetProjectById]
	@Id int
	As
Begin
	select * From [dbo].[V_ProjectDetails] AS PD
	Where PD.[Id] = @Id
	Return 1024;
End