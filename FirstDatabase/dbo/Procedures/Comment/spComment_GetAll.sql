CREATE PROCEDURE [dbo].[spComment_GetAll]
AS
begin
	select id, user_id, comment, topic_id, post_id
	From dbo.[Comments];
end
