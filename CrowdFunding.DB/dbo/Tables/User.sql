﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY,
	[Login] VARCHAR(255) NOT NULL,
	[Email] VARCHAR(255) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[FirstName] VARCHAR(50) NOT NULL,
	[EncodedPassword] BINARY(64) NOT NULL,
	[BirthDate] DATE NULL,
	[Salt] VARCHAR(255) NOT NULL,
	[Active] BIT not null DEFAULT 0,
	[Role] VARCHAR(25) NOT NULL DEFAULT 'USER_SIMPLE',
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [UQ_User_email] UNIQUE([Email]),
	CONSTRAINT [UQ_UserLogin] UNIQUE([Login]),
	CONSTRAINT [UQ_UserSalt] UNIQUE([Salt])
)
