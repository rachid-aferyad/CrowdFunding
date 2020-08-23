﻿CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(255) NULL,
	CONSTRAINT [PKCategory] PRIMARY KEY([Id]),
	CONSTRAINT [UQCategoryName] UNIQUE([Name])
)
