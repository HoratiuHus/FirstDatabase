CREATE PROCEDURE [dbo].[spTopic_Update]
		@Id			int,
		@UpVotes	int,
		@DownVotes	int
AS
begin
	update dbo.[Topic] 
	set upvotes = @UpVotes, downvotes = @DownVotes
	where id = @Id;
end