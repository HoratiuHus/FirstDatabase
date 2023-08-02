CREATE PROCEDURE [dbo].[spPost_Get]
	@Id int
AS
begin
	select id, title, body, user_id, topic_id, upvotes, downvotes, created_at
	from dbo.[Posts]
	where Id = @Id;
end
