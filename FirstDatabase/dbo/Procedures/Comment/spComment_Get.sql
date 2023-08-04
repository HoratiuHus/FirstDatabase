CREATE PROCEDURE [dbo].[spComment_Get]
	@PostId int
AS
begin
	select id, user_id, comment, topic_id, post_id
	from dbo.[Comments]
	where post_id = @PostId;
end
