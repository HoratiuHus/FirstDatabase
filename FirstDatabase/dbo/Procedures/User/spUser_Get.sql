CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
begin
	select id, email, username, password, createdat
	from dbo.[Users]
	where Id = @Id;
end
