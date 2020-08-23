CREATE TYPE BankAccountType
   AS TABLE
      ( 
        [AccountNumber] varchar(255) not null,
        [Country] varchar(255) not null
      )