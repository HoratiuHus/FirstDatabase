namespace Models.Response
{
    public class CommentRequest
    {
        public CommentRequest(string comment, int userId, int postId, int topicId)
        {
            Comment = comment;
            UserId = userId;
            PostId = postId;
            TopicId = topicId;
        }

        public string Comment { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public int TopicId { get; set; }
    }
}