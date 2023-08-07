
namespace Models.Request
{
    public class PostRequest
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public int TopicId { get; set; }

        public int UserId { get; set; }
    }
}
