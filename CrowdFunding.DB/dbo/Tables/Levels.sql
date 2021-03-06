﻿CREATE TABLE [dbo].[Level]
(
	[Id] INT NOT NULL IDENTItY,
	[Title] VARCHAR(100) NOT NULL,
	[Amount] MONEY NOT NULL,
	[Award] VARCHAR(255) NOT NULL,
	[ProjectId] INT NOT NULL,
    CONSTRAINT [PK_Level] PRIMARY KEY([Id]),
	CONSTRAINT [FK_LevelProject]
		FOREIGN KEY ([ProjectId]) REFERENCES [Project]([Id])
		ON DELETE CASCADE
)
