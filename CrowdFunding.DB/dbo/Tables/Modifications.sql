CREATE TABLE [dbo].[Modification]
(
	[Id] INT NOT NULL IDENTItY,
	[ProjectId] INT NOT NULL,
	[ModificationDate] DATETIME NOT NULL,
	CONSTRAINT [PK_Modification] PRIMARY KEY([Id]),
	CONSTRAINT [FK_ModificationProject] 
		FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
)
