using DataAccess.DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly ISqlDataAccess _db;

        public PostController(ISqlDataAccess db)
        {
            _db = db;
        }

        // GET: api/<Post>
        [HttpGet]
        public async Task<IEnumerable<PostResponse>> GetPosts()
        {
            var posts = await _db.LoadDataAsync<Post, dynamic>(storedProcedure: "dbo.spPost_GetAll", new { });
            List<PostResponse> postsResponse = new List<PostResponse>();
            foreach (var post in posts)
            {
                postsResponse.Add(new PostResponse(post.Id, post.Title, post.Body, post.User_ID,
                    post.Topic_ID, post.UpVotes, post.DownVotes, post.CreatedAt));
            }

            return postsResponse;
        }

        // GET api/<Post>/5
        [HttpGet("{id}")]
        public async Task<PostResponse?> GetPostByID(int id, PostResponse post)
        {
            var results = await _db.LoadDataAsync<Post, dynamic>(
            storedProcedure: "dbo.spPost_Get",
            new { Id = id });
            return new PostResponse(post.Id, post.Title, post.Body, post.UserID,
                    post.TopicID, post.UpVotes, post.DownVotes, post.CreatedAt);
        }

        // POST api/<Post>
        [HttpPost("{id}")]
        public Task Post([FromBody] PostRequest post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Insert", new { post.Title, post.Body, post.UserID,
                post.TopicID, UpVotes = 0, DownVotes = 0  , CreatedAt = DateTime.Now });
        }

        // PUT api/<Post>/5
        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] PostRequest post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Update", new { post.Title, post.Body, post.TopicID });
        }

        // DELETE api/<Post>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Delete", new { Id = id });
        }
    }
}
