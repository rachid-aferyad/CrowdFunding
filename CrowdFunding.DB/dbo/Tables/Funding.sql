CREATE TABLE [dbo].[Funding]
(
	[FunderId] INT NOT NULL,
	[ProjectId] INT NOT NULL,
	[FundingDate] DateTIME NOT NULL,
	[Amount] MONEY NOT NULL,
	CONSTRAINT [PK_Funding] PRIMARY KEY([FunderId], [ProjectId], [FundingDate]),
	CONSTRAINT [FK_Funding_User] 
		FOREIGN KEY ([FunderId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_FundingProject] 
		FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
)
