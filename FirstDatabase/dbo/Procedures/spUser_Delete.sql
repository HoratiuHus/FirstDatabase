CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Users]
	where id = @Id;
end
