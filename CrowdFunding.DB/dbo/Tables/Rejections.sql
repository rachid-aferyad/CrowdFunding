CREATE TABLE [dbo].[Rejection]
(
	[RejectorId] INT NOT NULL,
	[ProjectId] INT NOT NULL,
	[RejectionDate] DATETIME NOT NULL,
	[Comment] VARCHAR(255) NOT NULL,
	CONSTRAINT [PK_Rejection] PRIMARY KEY([RejectorId], [ProjectId], [RejectionDate]),
	CONSTRAINT [FK_Rejection_User] 
		FOREIGN KEY ([RejectorId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_RejectionProject] 
		FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
)
