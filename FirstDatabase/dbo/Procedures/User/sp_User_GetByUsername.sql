CREATE PROCEDURE [dbo].[spUser_GetByUsername]
	@Username nvarchar(50)
AS
begin
	select id, email, username, password, createdat, role
	from dbo.[Users]
	where username = @Username;
end
