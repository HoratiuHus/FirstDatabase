CREATE PROCEDURE [dbo].[spPost_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Posts]
	where id = @Id;
end