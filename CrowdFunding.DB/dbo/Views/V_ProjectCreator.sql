CREATE VIEW [dbo].[V_ProjectCreator]
	AS SELECT 
		P.[Id],
		P.[CreatorId],
		P.[Title],
		P.[Description],
		P.[VideoLink],
		P.[LevelType],
		P.[CreationDate],
		P.[ActivedForValidation],
		P.[FundingCeiling]
		--(Select P.[ValidationDate]) AS [validation],
		--(Select C.[CategoryId], C.[Name], C.[Description]) AS categories,
		--(Select L.[levelId], L.[Title], L.[Amount], L.[award]) AS levels,
		--(Select F.[Amount], F.[FundingDate]) AS funding,
		--(Select M.[ModificationDate]) AS modifications,
		--(Select R.[RejectionDate], R.[Comment]) AS rejections
	FROM [dbo].[Project] P
		LEFT JOIN [dbo].[CategoriesProjects] AS CP
			ON CP.[ProjectId] = P.[Id]
		LEFT JOIN [dbo].[Category] AS C
			ON C.[Id] = CP.[CategoryId]
		LEFT JOIN [dbo].[Level] AS L
			ON L.[ProjectId] = P.[Id]
		LEFT JOIN [dbo].[Funding] AS F
			ON F.[ProjectId] = P.[Id]
		LEFT JOIN [dbo].[Modification] AS M
			ON M.[ProjectId] = P.[Id]
		LEFT JOIN [dbo].[Rejection] AS R
			ON R.[ProjectId] = P.[Id]