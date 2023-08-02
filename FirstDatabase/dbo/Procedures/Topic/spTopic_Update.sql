CREATE PROCEDURE [dbo].[spTopic_Update]
		@Id			int,
		@Topic_Name	nvarchar(50),
		@UpVotes	int,
		@DownVotes	int
AS
begin
	update dbo.[Topic] 
	set topic_name = @Topic_Name, upvotes = @UpVotes, downvotes = @DownVotes
	where id = @Id;
end