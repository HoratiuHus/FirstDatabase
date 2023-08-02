
namespace Models.Request
{
    public class TopicRequest
    {

        public TopicRequest(string topicName)
        {
            TopicName = topicName;
        }

        public string TopicName { get; set; }
    }
}
