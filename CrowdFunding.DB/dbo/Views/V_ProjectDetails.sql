CREATE VIEW [dbo].[V_ProjectDetails]
	AS SELECT 
		P.[Id],
		P.[Title],
		P.[Description],
		P.[VideoLink],
		P.[LevelType],
		P.[CreationDate],
		P.[BankAccountId],
		P.[CreatorId],
		P.[FundingCeiling],
		FP.[TotalFunding],
		FP.[NumberFunders]
		--C.[categoryId],
		 --SUM(F.[amount]) AS total_funding
	FROM [dbo].[Project] P
		--LEFT JOIN [dbo].[CategoriesProjects] AS CP
		--	ON CP.[projectId] = P.[projectId]
		--LEFT JOIN [dbo].[Categories] AS C
		--	ON C.[categoryId] = CP.[categoryId]
		LEFT JOIN [dbo].[V_ProjectFunding] AS FP
			ON FP.[ProjectId] = P.[id]
		--(Select C.[categoryId], C.[name], C.[description]) AS categories,
		--(Select L.[levelId], L.[title], L.[amount], L.[award]) AS levels,
		--(Select F.[amount], F.[fundingDate]) AS funding
	--FROM [dbo].[Project] P
		--LEFT JOIN [dbo].[CategoriesProjects] AS CP
		--	ON CP.[projectId] = P.[id]
		--LEFT JOIN [dbo].[Category] AS C
		--	ON C.[id] = CP.[categoryId]
		--LEFT JOIN [dbo].[Level] AS L
		--	ON L.[projectId] = P.[id]
		--LEFT JOIN [dbo].[Funding] AS F
		--	ON F.[projectId] = P.[id]