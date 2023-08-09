using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class PostResponse
    {
        public PostResponse(int id, string title, string body, int userId, int topicId, int upVotes, int downVotes, DateTime createdAt, List<CommentResponse> comments )
        {
            Id = id;
            Title = title;
            Body = body;
            UserID = userId;
            TopicID = topicId;
            UpVotes = upVotes;
            DownVotes = downVotes;
            CreatedAt = createdAt;
            Comments = comments;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int UserID { get; set; }

        public int TopicID { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CommentResponse> Comments { get; set; }
    }
}
