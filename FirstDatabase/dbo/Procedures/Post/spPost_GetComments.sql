CREATE PROCEDURE [dbo].[spPost_GetComments]
	@Id int

AS
begin
SELECT TOP (1000) U.username, P.*
  FROM [dbo].[Posts] P
  JOIN [dbo].Users U on U.id = P.[user_id]

  WHERE P.Id = @Id


  SELECT username, C.* FROM [dbo].Comments C
  JOIN [dbo].[Users] U on C.[user_id] = U.Id
  WHERE post_id = @Id
END