CREATE PROCEDURE [dbo].[CSP_UpdateBankAccount]
	@Id int,
	@AccountNumber varchar(255),
	@Country varchar(255)

AS
BEGIN
	UPDATE [dbo].[BankAccount] 
		SET [AccountNumber] = @AccountNumber, [Country] = @Country
		Where Id = @Id
		RETURN;
END