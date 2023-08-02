CREATE PROCEDURE [dbo].[spUser_Insert]
		@Email	  nvarchar(70),
		@Username nvarchar(50),
		@Password nvarchar(50),
		@Createdat DateTime
AS
begin
	insert into dbo.[Users] (email, username, password, createdat)
	values (@Email, @UserName, @Password, @Createdat);
end