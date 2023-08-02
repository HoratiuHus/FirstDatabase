CREATE PROCEDURE [dbo].[spPost_Insert]
		@Title	   nvarchar(50),
		@Body	   nvarchar(max),
		@UserId	   int,
		@TopicId   int,
		@UpVotes   int,
		@DownVotes int,
		@CreatedAt DateTime

AS
begin
	insert into dbo.[Posts] (title, body, user_id, topic_id, upvotes, downvotes, created_at)
	values (@Title, @Body, @UserId, @TopicId, @UpVotes, @DownVotes, @CreatedAt);
end
