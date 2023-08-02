using DataAccess.Data.Interfaces;
using DataAccess.DatabaseAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class TopicData : ITopicData
    {

        private readonly ISqlDataAccess _db;

        public TopicData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Topic>> GetTopicsAsync()
        {
            return await _db.LoadDataAsync<Topic, dynamic>(storedProcedure: "dbo.spTopic_GetAll", new { });
        }

        public async Task<Topic?> GetTopicByIDAsync(int id)
        {
            var results = await _db.LoadDataAsync<Topic, dynamic>(
                storedProcedure: "dbo.spTopic_Get",
                new { Id = id });
            return results.FirstOrDefault(); // This will return the first record in IEnumarable or the default value(null)
                                             //Here we are loading the data, we are asking of an IEnumerable of UserModel
                                             //And we are creating a new object(id) which is being passed by the constructor
        }

        public Task InsertTopicAsync(Topic topic)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spTopic_Insert", new { topic.TopicName, topic.UpVotes, topic.DownVotes });
        }

        public Task UpdateTopicAsync(Topic topic)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spTopic_Update", topic);
        }

        public Task DeleteTopicAsync(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spTopic_Delete", new { Id = id });
        }


    }
}
