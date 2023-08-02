CREATE PROCEDURE [dbo].[spTopic_GetAll]
AS
begin
	select id, topic_name, upvotes, downvotes
	From dbo.[Topic];
end