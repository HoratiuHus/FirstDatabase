CREATE PROCEDURE [dbo].[spPost_GetAll]
AS
begin
	select id, title, body, user_id, topic_id, upvotes, downvotes, created_at
	From dbo.[Posts];

	select *
	from dbo.[Comments]
end
