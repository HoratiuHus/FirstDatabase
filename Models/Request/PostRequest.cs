
namespace Models.Request
{
    public class PostRequest
    {
        public PostRequest(string title, string body, int topicId, int userId)
        {
            Title = title;
            Body = body;
            TopicID = topicId;
            UserID = userId;
        }

        public string Title { get; set; }

        public string Body { get; set; }

        public int TopicID { get; set; }

        public int UserID { get; set; }
    }
}
