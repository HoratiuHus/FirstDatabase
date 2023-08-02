CREATE PROCEDURE [dbo].[spTopic_Delete]
	@Id int
AS
begin
	delete
	from dbo.[Topic]
	where id = @Id;
end
