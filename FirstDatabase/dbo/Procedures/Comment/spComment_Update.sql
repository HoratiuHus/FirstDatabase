CREATE PROCEDURE [dbo].[spComment_Update]
		@Id		   int,
		@Comment   nvarchar(max),
		@TopicId   int,
		@PostId    int
AS
begin
	update dbo.[Comments] 
	set comment = @Comment, topic_id = @TopicId, post_id = @PostId
	where id = @Id;
end