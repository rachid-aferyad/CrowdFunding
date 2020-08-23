CREATE PROCEDURE [dbo].[CSP_GetAllProjectsForAdmin]
	As
Begin
	select * From [dbo].[V_ProjectAdmin]
	Return 1024;
End