CREATE TABLE [dbo].[CategoriesProjects]
(
	[CategoryId] INT NOT NULL,
	[ProjectId] INT NOT NULL,
	CONSTRAINT [PKCategoryProject] PRIMARY KEY([CategoryId], [ProjectId]),
	CONSTRAINT [FKCategoryProjectCategory]
		FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id])
		ON DELETE CASCADE,
	CONSTRAINT [FKCategoryProjectProject]
		FOREIGN KEY([ProjectId]) REFERENCES [Project]([Id])
		ON DELETE CASCADE
)
