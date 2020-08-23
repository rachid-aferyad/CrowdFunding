CREATE TYPE [dbo].[LevelArray]
   AS TABLE
      ( 
		[LevelId] int NOT NULL,
		[Title] VARCHAR(100) NOT NULL,
		[Amount] MONEY NOT NULL,
		[Award] VARCHAR(255) NOT NULL
      )
