CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [title] NVARCHAR(100) NOT NULL, 
    [body] TEXT NOT NULL, 
    [user_id] INT NOT NULL, 
    [comment] TEXT NULL, 
    [topic_id] INT NOT NULL, 
    [upvotes] INT NULL, 
    [downvotes] INT NULL, 
    CONSTRAINT [FK_Posts_Users] FOREIGN KEY ([user_id]) REFERENCES [Users]([id])
)
