CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select id, email, username, password, createdat
	From dbo.[Users];
end
