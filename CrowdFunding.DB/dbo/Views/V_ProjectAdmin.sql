CREATE VIEW [dbo].[V_ProjectAdmin]
	AS SELECT
		P.[Id],
		P.[Title],
		P.[Description],
		P.[VideoLink],
		P.[LevelType],
		P.[CreationDate],
		P.[Active],
		P.[activedForValidation],
		P.[FundingCeiling]
		--P.[BankAccountId]
		--(Select U.[FirstName], U.[LastName]) AS creator,
		--(Select P.[ValidationDate], (Select P.[ValidatorId], U.[FirstName], U.[LastName]  Where P.[ValidatorId] = U.[userId]) AS validator) AS [validation],
		--(Select C.[CategoryId], [Name], C.[Description]) AS categories,
		--(Select L.[levelId], L.[Title]) AS levels,
		--(Select F.[FunderId], F.[Amount], (Select F.[FunderId], U.[FirstName], U.[LastName]  Where F.[FunderId] = U.[userId]) AS funder) AS funding,
		--(Select M.[ModificationDate]) AS modifications,
		--(Select R.[RejectionDate], R.[Comment], (Select R.[RejectorId], U.[FirstName], U.[LastName] Where R.[RejectorId] = U.[userId]) AS rejector) AS rejections,
		--(Select BA.[BankAccountId], BA.[AccountNumber]) AS bankAccount
	FROM [dbo].[Project] P
		LEFT JOIN [dbo].[User] AS U
			ON P.[CreatorId] = U.[Id]
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
		--LEFT JOIN [dbo].[BankAccount] AS BA
			--ON BA.[ProjectId] = P.[Id]