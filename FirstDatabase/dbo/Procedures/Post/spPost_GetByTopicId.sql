CREATE PROCEDURE [dbo].[spPost_GetByTopicId]
	@TopicId int
AS
begin
	select id, title, body, user_id, topic_id, upvotes, downvotes, created_at
	from dbo.[Posts]
	where topic_id = @TopicId;
end
