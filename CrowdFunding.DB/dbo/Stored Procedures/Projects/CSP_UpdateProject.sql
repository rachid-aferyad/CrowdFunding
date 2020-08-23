CREATE PROCEDURE [dbo].[CSP_UpdateProject]
	@Id int,
	@Title nvarchar(100),
	@Description varchar(255),
	@VideoLink varchar(255),
	@LevelType varchar(25),
	@FundingCeiling money,
	@CreatorId int,
	@BankAccountId int,
	@AccountNumber varchar(255),
	@Country varchar(255),
	@Categories [dbo].[CategoryArray] readonly,
	@Levels LevelArray readonly

AS
BEGIN

	Set NoCount On;
	Delete from [CategoriesProjects] Where [ProjectId] = @Id
	Insert into [CategoriesProjects] ([ProjectId], [CategoryId]) Select @Id, CategoryId from @Categories
	Set NoCount Off;

	Set NoCount On;
	--WHILE(EXISTS(Select LevelId, Title, Amount, Award from @Levels))
	--	BEGIN
	--		EXEC CSP_UpdateLevel @Id = LevelId, @Title = Title, @Amount = Amount, @Award = Award
	--	END


		DECLARE @LevelTitle VARCHAR(50)
		DECLARE @LevelAmount VARCHAR(256)
		DECLARE @LevelAward VARCHAR(256)
		DECLARE @LevelId int

		DECLARE db_cursor CURSOR FOR 
		SELECT LevelId, Title, Amount, Award from @Levels 

		OPEN db_cursor

		FETCH NEXT FROM db_cursor INTO @LevelId , @LevelTitle, @LevelAmount, @LevelAward

		WHILE @@FETCH_STATUS = 0  
 
			BEGIN  
				EXEC CSP_UpdateLevel @Id = @LevelId, @Title = @LevelTitle, @Amount = @LevelAmount, @Award = @LevelAward
				Fetch db_cursor Into @LevelId , @LevelTitle, @LevelAmount, @LevelAward
			END 

		CLOSE db_cursor  
		DEALLOCATE db_cursor 

	Set NoCount Off;

	Set NoCount On;
		EXEC CSP_UpdateBankAccount @Id = @BankAccountId, @AccountNumber = @AccountNumber, @Country = @Country
	Set NoCount Off;

	UPDATE [dbo].[Project] 
		SET [Title] = @Title, [Description] = @Description, [VideoLink] = @VideoLink, [LevelType] = @LevelType, [FundingCeiling] = @FundingCeiling
			Where Id = @Id;
		RETURN;
END

