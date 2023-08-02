CREATE TABLE [dbo].[Posts_Topic]
(
	[post_id] INT NOT NULL , 
    [topic_id] INT NOT NULL, 
    PRIMARY KEY ([topic_id], [post_id]), 
    CONSTRAINT [FK_Posts_Topic_Topic] FOREIGN KEY ([topic_id]) REFERENCES [Topic]([id]), 
    CONSTRAINT [FK_Posts_Topic_Posts] FOREIGN KEY ([post_id]) REFERENCES [Posts]([id])
)
