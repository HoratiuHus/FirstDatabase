using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Topic
    {
        public int Id { get; set; }

        public string TopicName { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }
    }
}
