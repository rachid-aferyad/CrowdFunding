CREATE PROCEDURE [dbo].[CSP_UpdateLevel]
	@Id int = 0,
	@Title varchar(255),
	@Amount money,
	@Award varchar(255)
AS
	Update [Level]
		Set Title = @Title, Amount = @Amount, Award = @Award
		Where Id = @Id
RETURN 0
