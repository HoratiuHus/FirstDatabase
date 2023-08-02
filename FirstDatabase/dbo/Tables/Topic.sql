CREATE TABLE [dbo].[Topic]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [topic_name] NVARCHAR(50) NOT NULL, 
    [comment] TEXT NULL, 
    [upvotes] INT NULL, 
    [downvotes] INT NULL
)
