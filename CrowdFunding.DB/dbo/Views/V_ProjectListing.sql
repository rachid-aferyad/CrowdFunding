CREATE VIEW [dbo].[V_ProjectListing]
	AS SELECT
		P.[Id],
		P.[Title],
		P.[Description],
		P.[VideoLink],
		P.[LevelType],
		P.[CreationDate],
		P.[FundingCeiling],
		FP.[ProjectId],
		FP.[TotalFunding]
		--C.[CategoryId],
		 --SUM(F.[Amount]) AS totalFunding
	FROM [dbo].[Project] P
		--LEFT JOIN [dbo].[CategoriesProjects] AS CP
		--	ON CP.[ProjectId] = P.[ProjectId]
		--LEFT JOIN [dbo].[Categories] AS C
		--	ON C.[CategoryId] = CP.[CategoryId]
		LEFT JOIN [dbo].[V_ProjectFunding] AS FP
			ON FP.[ProjectId] = P.[Id]
		--Group By F.[ProjectId]