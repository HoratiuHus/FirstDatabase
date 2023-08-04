CREATE PROCEDURE [dbo].[spComment_Insert]
		@Comment   nvarchar(max),
		@UserId		int,
		@TopicId   int,
		@PostId    int
AS
begin
	insert into dbo.[Comments] (comment ,user_id, topic_id, post_id)
	values (@Comment,@UserId, @TopicId, @PostId);
end
