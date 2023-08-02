using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int User_ID { get; set; }

        public int Topic_ID { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
