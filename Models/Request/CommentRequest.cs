namespace Models.Request
{
    public class CommentRequest
    {

        public string Comment { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public int TopicId { get; set; }
    }
}