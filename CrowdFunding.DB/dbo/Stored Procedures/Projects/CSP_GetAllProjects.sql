CREATE PROCEDURE [dbo].[CSP_GetAllProjects]
As
Begin
	select * From [dbo].[V_ProjectListing]
	Return 1024;
End