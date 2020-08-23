CREATE PROCEDURE [dbo].[CSP_AddFunding]
	@ProjectId int,
	@FunderId int,
	@Amount money
As
Begin
	Insert into [dbo].[Funding] ([ProjectId], [FunderId], [Amount], [FundingDate])
	Values (@ProjectId, @FunderId, @Amount, GETDATE());
	--select SCOPEIDENTITY();
End