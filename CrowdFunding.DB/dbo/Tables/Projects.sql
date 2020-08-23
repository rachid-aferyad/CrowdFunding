CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL IDENTITY,
	[Title] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(255) NULL,
	[VideoLink] VARCHAR(255) NULL,
	[ActivedForValidation] BIT NOT NULL DEFAULT 0,
	[Active] BIT NOT NULL DEFAULT 0,
	[LevelType] VARCHAR(25) NULL,
	[FundingCeiling] money,
	[CreationDate] DateTIME NOT NULL,
	[ValidationDate] DateTIME NULL,
	[CreatorId] INT NOT NULL,
	[ValidatorId] INT NULL,
	[BankAccountId] INT NOT NULL,
	CONSTRAINT [PK_Project] PRIMARY KEY([Id]),
	CONSTRAINT [FK_Project_Creator]
		FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Project_Validator]
		FOREIGN KEY ([ValidatorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_Project_BankAccount]
		FOREIGN KEY ([BankAccountId]) REFERENCES [BankAccount]([Id]),
	CONSTRAINT [UQ_Project_Title] UNIQUE([Title])
)

GO