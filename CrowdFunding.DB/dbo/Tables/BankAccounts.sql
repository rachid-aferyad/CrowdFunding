CREATE TABLE [dbo].[BankAccount]
(
	[Id] INT NOT NULL IDENTITY,
	[AccountNumber] VARCHAR(50) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_BankAccount] PRIMARY KEY([Id]),
	CONSTRAINT [UQ_BankAccountNumber] UNIQUE([AccountNumber])
)
