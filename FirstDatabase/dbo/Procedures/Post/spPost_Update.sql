CREATE PROCEDURE [dbo].[spPost_Update]
		@Id		   int,
		@Title	   nvarchar(50),
		@Body	   text,
		@UserId	   int,
		@TopicId   int,
		@Upvotes   int,
		@Downvotes int,
		@CreatedAt DateTime
AS
begin
	update dbo.[Posts] 
	set title = @Title, body = @Body, topic_id = @TopicId
	where id = @Id;
end