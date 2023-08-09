using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class PostUpdateRequest
    {
        //public PostUpdateRequest(int id, string postTitle, int upVotes, int downVotes)
        //{
        //    Id = id;
        //    Title = postTitle;
        //    UpVotes = upVotes;
        //    DownVotes = downVotes;
        //}

        public int Id { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }
    }
}
