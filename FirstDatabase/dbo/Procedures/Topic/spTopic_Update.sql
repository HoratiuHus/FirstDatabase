CREATE PROCEDURE [dbo].[spTopic_Update]
		@Id			int,
		@TopicName	nvarchar(50),
		@UpVotes	int,
		@DownVotes	int
AS
begin
	update dbo.[Topic] 
	set topic_name = @TopicName, upvotes = @UpVotes, downvotes = @DownVotes
	where id = @Id;
end