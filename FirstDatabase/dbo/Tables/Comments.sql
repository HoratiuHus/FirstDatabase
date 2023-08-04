CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] INT NOT NULL, 
    [comment] NVARCHAR(MAX) NOT NULL, 
    [post_id] INT NULL, 
    [topic_id] INT NULL, 
    CONSTRAINT [FK_Comments_Users] FOREIGN KEY ([user_id]) REFERENCES [Users]([id]), 
    CONSTRAINT [FK_Comments_Posts] FOREIGN KEY ([post_id]) REFERENCES [Posts]([id]), 
    CONSTRAINT [FK_Comments_Topic] FOREIGN KEY ([topic_id]) REFERENCES [Topic]([id]) 
)
