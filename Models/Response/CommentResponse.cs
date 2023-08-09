using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Response
{
    public class CommentResponse
    {
        public CommentResponse(int id, int userId, string comment, int post_Id, int topic_Id)
        {
            Id = id;
            UserId = userId;
            Comment = comment;
            Post_Id = post_Id;
            Topic_Id = topic_Id;
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public string Comment { get; set; }

        public int Post_Id { get; set; }

        public int Topic_Id { get; set; }
    }
}
