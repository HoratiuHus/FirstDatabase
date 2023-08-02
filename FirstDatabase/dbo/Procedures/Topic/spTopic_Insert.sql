CREATE PROCEDURE [dbo].[spTopic_Insert]
		@TopicName	nvarchar(50),
		@UpVotes	int,
		@DownVotes	int
AS
begin
	insert into dbo.[Topic] (topic_name, upvotes, downvotes)
	values (@TopicName, @UpVotes, @DownVotes);
end