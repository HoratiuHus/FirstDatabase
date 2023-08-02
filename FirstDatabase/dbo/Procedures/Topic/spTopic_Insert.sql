CREATE PROCEDURE [dbo].[spTopic_Insert]
		@Topic_Name	nvarchar(50),
		@UpVotes	int,
		@DownVotes	int
AS
begin
	insert into dbo.[Topic] (topic_name, upvotes, downvotes)
	values (@Topic_Name, @UpVotes, @DownVotes);
end