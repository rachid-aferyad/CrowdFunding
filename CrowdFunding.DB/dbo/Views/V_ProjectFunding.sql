CREATE VIEW [dbo].[V_ProjectFunding]
	AS SELECT
		F.[ProjectId],
		COUNT(F.[ProjectId]) AS NumberFunders,
		SUM(F.[Amount]) AS TotalFunding

		FROM [dbo].[Funding] AS F
		Group By F.[ProjectId]