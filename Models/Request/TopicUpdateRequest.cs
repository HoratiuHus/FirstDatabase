
namespace Models.Request
{
    public class TopicUpdateRequest
    {

        //public TopicUpdateRequest(int upVotes, int downVotes)
        //{
        //    UpVotes = upVotes;
        //    DownVotes = downVotes;
        //}

        public int Id { get; set; }

        public int UpVotes{ get; set; }

        public int DownVotes { get; set; }
    }
}
