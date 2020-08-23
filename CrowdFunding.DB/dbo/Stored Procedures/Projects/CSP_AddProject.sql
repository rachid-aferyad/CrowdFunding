CREATE PROCEDURE [dbo].[CSP_AddProject]
	@Title nvarchar(100),
	@Description varchar(255),
	@VideoLink varchar(255),
	@LevelType varchar(25),
	@FundingCeiling money,
	@CreatorId int,
	@AccountNumber varchar(255),
	@Country varchar(255),
	@Categories [dbo].[CategoryArray] readonly,
	@Levels LevelArray readonly

As
Begin

	Insert into [dbo].[BankAccount]([AccountNumber], [Country])
	Values(@AccountNumber, @Country)
	Declare @BankAccountId int = Scope_Identity();

	Insert into [dbo].[Project] ([Title], [Description], [VideoLink], [LevelType], [FundingCeiling], [CreatorId], [BankAccountId], [CreationDate])
	Values (@Title, @Description, @VideoLink, @LevelType, @FundingCeiling, @CreatorId,@BankAccountId, GETDATE());
	Declare @Id int = Scope_Identity();

	Set NoCount On;
	Insert into [dbo].[CategoriesProjects]([ProjectId], [CategoryId])
	Select @Id, CategoryId from @Categories

	Set NoCount On;
	if(EXISTS (Select * from @Levels))
		Begin
			Insert into [dbo].[Level]([ProjectId], [Title], [Amount], [Award])
			Select @Id, Title, Amount, Award from @Levels
		End

End