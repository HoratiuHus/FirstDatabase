CREATE PROCEDURE [dbo].[spTopic_Get]
	@Id int
AS
begin
	select id, topic_name, upvotes, downvotes
	from dbo.[Topic]
	where Id = @Id;
end
