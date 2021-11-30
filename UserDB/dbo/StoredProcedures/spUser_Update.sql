﻿CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int
	,@FirstName nvarchar(50)
	,@LastName nvarchar(50)
AS
	UPDATE dbo.[User]
	set FirstName = @FirstName
	, LastName = @LastName
	WHERE Id = @Id;
RETURN 0
