CREATE PROCEDURE [dbo].[CSP_AddBankAccount]
	@AccountNumber nvarchar(255),
	@Country varchar(255)

As
Begin
	Insert into [dbo].[BankAccount] ([AccountNumber], [Country]) output inserted.id
	Values (@AccountNumber, @Country);
End