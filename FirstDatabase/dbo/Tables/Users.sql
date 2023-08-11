CREATE TABLE [dbo].Users
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [email] NVARCHAR(70) NOT NULL, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [createdat] DATETIME NOT NULL, 
    [role] NVARCHAR(20) NULL DEFAULT 'User'
)
