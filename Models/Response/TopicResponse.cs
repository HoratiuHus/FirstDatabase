namespace Models.Response
{
    public class TopicResponse
    {
        public TopicResponse(int id, string topicName, int upVotes, int downVotes)
        {
            Id = id;
            TopicName = topicName;
            UpVotes = upVotes;
            DownVotes = downVotes;
        }

        public int Id { get; set; }

        public string TopicName { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }
    }
}
