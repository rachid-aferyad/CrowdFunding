CREATE PROCEDURE [dbo].[CSP_CheckUser]
	@Email nvarchar(255),
	@Login nvarchar(255),
	@Password nvarchar(20),
	@Salt nvarchar(255)
As
Begin
	Select VU.*
	From [dbo].[User] AS U
		LEFT JOIN [dbo].[V_User] AS VU
			ON VU.[Id] = U.[Id] 
				And (U.[Email] = @Email Or U.[Login] = @Login)
				And U.[EncodedPassword] = [dbo].[SF_HashPassword](@Password, @Salt)
End