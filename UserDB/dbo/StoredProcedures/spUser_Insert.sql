﻿CREATE PROCEDURE [dbo].[spUser_Insert]
	@FirstName nvarchar(50)
	,@LastName nvarchar(50)
AS
	INSERt INTO dbo.[User] (FirstName, LastName)
	VALUES (@FirstName, @LastName);
RETURN 0
