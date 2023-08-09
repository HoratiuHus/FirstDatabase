CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	select id, email, username, password, createdat, role
	From dbo.[Users];
end
