CREATE PROCEDURE [dbo].[spComment_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Comments]
	where id = @Id;
end