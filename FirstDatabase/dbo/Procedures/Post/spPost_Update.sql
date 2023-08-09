CREATE PROCEDURE [dbo].[spPost_Update]
		@Id		   int,
		@Upvotes   int,
		@Downvotes int
AS
begin
	update dbo.[Posts] 
	SET upvotes = @Upvotes, downvotes = @Downvotes  
	where id = @Id;
end