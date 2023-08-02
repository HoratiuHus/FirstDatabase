CREATE PROCEDURE [dbo].[spUser_Update]
		@Id int,
		@Email	  nvarchar(70),
		@Username nvarchar(50),
		@Password nvarchar(50),
		@Created_at timestamp
AS
begin
	update dbo.[Users] 
	set email = @Email, username = @Username, password = @Password
	where id = @Id;
end