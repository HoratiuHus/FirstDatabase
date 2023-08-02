CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [title] NVARCHAR(100) NOT NULL, 
    [body] NVARCHAR(MAX) NOT NULL, 
    [user_id] INT NOT NULL, 
    [topic_id] INT NOT NULL, 
    [upvotes] INT NULL, 
    [downvotes] INT NULL, 
    [created_at] DATETIME NOT NULL, 
    CONSTRAINT [FK_Posts_Users] FOREIGN KEY ([user_id]) REFERENCES [Users]([id])
)
