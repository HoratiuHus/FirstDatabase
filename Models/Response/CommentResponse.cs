using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class CommentResponse
    {
        public CommentResponse(int id, int userId, string comment, int postId, int topicId)
        {
            Id = id;
            UserId = userId;
            CommentText = comment;
            Post_Id = postId;
            Topic_Id = topicId;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string CommentText { get; set; }

        public int Post_Id { get; set; }

        public int Topic_Id { get; set; }
    }
}
