using DataAccess.DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {

        private readonly ISqlDataAccess _db;

        public TopicController(ISqlDataAccess db)
        {
            _db = db;
        }

        // GET: api/<Topic>
        [HttpGet]
        public async Task<IEnumerable<TopicResponse>> GetTopics()
        {
            var topics = await _db.LoadDataAsync<Topic, dynamic>(storedProcedure: "dbo.spTopic_GetAll", new { });
            List<TopicResponse> topicsResponse = new List<TopicResponse>();
            foreach (var topic in topics)
            {
                topicsResponse.Add(new TopicResponse(topic.Id, topic.Topic_Name, topic.UpVotes, topic.DownVotes));
            }

            return topicsResponse;
        }

        // GET api/<Topic>/5
        [HttpGet("{id}")]
        public async Task<TopicResponse?> GetTopicByID(int id, TopicResponse topic)
        {
            var results = await _db.LoadDataAsync<Topic, dynamic>(
            storedProcedure: "dbo.spTopic_Get",
            new { Id = id });
            return new TopicResponse(topic.Id, topic.TopicName, topic.UpVotes, topic.DownVotes);
        }

        // POST api/<Topic>
        [HttpPost]
        public Task Post([FromBody] TopicRequest topic)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spTopic_Insert", new { Topic_Name = topic.TopicName, UpVotes = 0, DownVotes = 0 });
        }

        // PUT api/<Topic>/5
        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] TopicUpdateRequest topic)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spTopic_Update", new { Id = topic.Id, Topic_Name = topic.TopicName , topic.UpVotes, topic.DownVotes });
        }

        // DELETE api/<Topic>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spTopic_Delete", new { Id = id });
        }
    }
}
