CREATE PROCEDURE [dbo].[CSP_AddUser]
	--@id int,
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@Email nvarchar(255),
	@Login nvarchar(255),
	@Password nvarchar(20),
	@BirthDate DATETIME,
	@Role nvarchar(25),
	@Salt varchar(25),
	@Active bit

As
Begin
	Insert into [dbo].[User] ([LastName], [FirstName], [Email], [Login], [EncodedPassword], [BirthDate], [Salt], [Role], [Active]) OUTPUT INSERTED.id
	Values (@LastName, @FirstName, @Email, @Login, [dbo].SF_HashPassword(@password, @Salt), @BirthDate, @Salt, @Role, @Active)
End