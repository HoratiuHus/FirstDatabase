using DataAccess.DatabaseAccess;
using DataAccess.Models;
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
                    post.Topic_ID, post.UpVotes, post.DownVotes, post.Created_At));
            }

            return postsResponse;
        }

        // GET api/<Post>/5
        [HttpGet("{id}")]
        public async Task<PostResponse?> GetPostByID(int id)
        {
            var results = await _db.LoadDataAsync<Post, dynamic>(
            storedProcedure: "dbo.spPost_Get",
            new { Id = id });
            var firstPost = results.FirstOrDefault();
            return new PostResponse(firstPost.Id, firstPost.Title, firstPost.Body, firstPost.User_ID,
                    firstPost.Topic_ID, firstPost.UpVotes, firstPost.DownVotes, firstPost.Created_At);
        }

        //GET api/<Post>/5
        [HttpGet("comments/{postId}")]
        public async Task<List<CommentResponse>> GetCommentByID(int postId)
        {
            var results = await _db.LoadDataAsync<CommentModel, dynamic>(
            storedProcedure: "dbo.spComment_Get",
            new { PostId = postId });
            List<CommentResponse> commentResponse = new List<CommentResponse>();
            foreach (var result in results)
                {
                    commentResponse.Add(new CommentResponse(result.Id, result.User_Id, result.Comment, result.Post_Id, result.Topic_Id));
                }
            return commentResponse;
        }
        // POST api/<Post>
        [HttpPost()]
        public Task Post([FromBody] PostRequest post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Insert", new { post.Title, post.Body, post.UserID,
                post.TopicID, UpVotes = 0, DownVotes = 0  , CreatedAt = DateTime.Now });
        }

        // PUT api/<Post>/5
        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] PostUpdateRequest post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Update", new { Id = post.Id, Title = post.Title, post.UpVotes, post.DownVotes });
        }

        // DELETE api/<Post>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Delete", new { Id = id });
        }
    }
}
