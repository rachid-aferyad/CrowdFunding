CREATE PROCEDURE [dbo].[CSP_GetProjectsByCategory]
	@CategoryId int
As
Begin
	select * From [dbo].[V_ProjectListing] AS PL
	--Where PL.[CategoryId] = @CategoryId
	Return 1024;
End