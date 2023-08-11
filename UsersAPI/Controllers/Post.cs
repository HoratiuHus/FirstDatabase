using DataAccess.DatabaseAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Models.Request;
using Models.Response;
using System.Security.Claims;

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
            var posts = await _db.LoadDataAsync<Post, Comments, dynamic>(storedProcedure: "dbo.spPost_GetAll", new { });
            List<PostResponse> postsResponse = new List<PostResponse>();
            List<CommentResponse> commentsResponse = new List<CommentResponse>();
            foreach (var comment in posts.Item2)
            {
                commentsResponse.Add(new CommentResponse(comment.Id, comment.User_Id,
                    comment.Comment, comment.Post_Id, comment.Topic_Id));
            }
            foreach (var post in posts.Item1)
            {
                var postComments = commentsResponse.Where(r => r.Post_Id == post.Id).ToList();
                postsResponse.Add(new PostResponse(post.Id, post.Title, post.Body, post.User_ID,
                    post.Topic_ID, post.UpVotes, post.DownVotes, post.Created_At, postComments));
            }

            return postsResponse;
        }

        [HttpGet("comments")]
        public async Task<IEnumerable<PostResponse>> GetPostsWithComments()
        {
            var posts = await _db.LoadDataAsync<Post, Comments, dynamic>(storedProcedure: "dbo.spPost_GetComments", new { });
            List< PostResponse > postsResponse = new List<PostResponse>();
            List<CommentResponse> commentsResponse = new List<CommentResponse>();
            
            foreach (var comment in posts.Item2)
            {
                commentsResponse.Add(new CommentResponse(comment.Id, comment.User_Id,
                    comment.Comment, comment.Post_Id, comment.Topic_Id));
            }
            foreach (var post in posts.Item1)
            {
                postsResponse.Add(new PostResponse(post.Id, post.Title, post.Body, post.User_ID,
                    post.Topic_ID, post.UpVotes, post.DownVotes, post.Created_At, commentsResponse));
            }

            return postsResponse;
        }

        // GET api/<Post>/5
        [HttpGet("{id}")]
        public async Task<PostResponse?> GetPostByID(int id)
        {
            var results = await _db.LoadDataAsync<Post, Comments, dynamic>(
            storedProcedure: "dbo.spPost_Get",
            new { Id = id });
            List<CommentResponse> commentsResponse = new List<CommentResponse>();
            foreach (var comment in results.Item2)
            {
                commentsResponse.Add(new CommentResponse(comment.Id, comment.User_Id,
                    comment.Comment, comment.Post_Id, comment.Topic_Id));
            }
            var firstPost = results.Item1.FirstOrDefault();
            return new PostResponse(firstPost.Id, firstPost.Title, firstPost.Body, firstPost.User_ID,
                    firstPost.Topic_ID, firstPost.UpVotes, firstPost.DownVotes, firstPost.Created_At, commentsResponse);
        }

        //GET api/<Post>/5
        [HttpGet("comments/{postId}")]
        public async Task<List<CommentResponse>> GetCommentByID(int postId)
        {
            var results = await _db.LoadDataAsync<Comments, dynamic>(
            storedProcedure: "dbo.spComment_Get",
            new { PostId = postId });
            List<CommentResponse> commentResponse = new List<CommentResponse>();
            foreach (var result in results)
                {
                    commentResponse.Add(new CommentResponse(result.Id, result.User_Id, result.Comment, result.Post_Id, result.Topic_Id));
                }
            return commentResponse;
        }

        //GET api/<Post>/5
        [HttpGet("topic/{topicId}")]
        public async Task<List<PostResponse>> GetPostsByTopicId(int topicId)
        {
            var results = await _db.LoadDataAsync<Post,Comments, dynamic>(
            storedProcedure: "dbo.spPost_GetByTopicId",
            new { TopicId = topicId });
            List<PostResponse> postResponse = new List<PostResponse>();
            List<CommentResponse> commentsResponse = new List<CommentResponse>();
            foreach (var comment in results.Item2)
            {
                commentsResponse.Add(new CommentResponse(comment.Id, comment.User_Id,
                    comment.Comment, comment.Post_Id, comment.Topic_Id));
            }
            foreach (var result in results.Item1)
            {
                postResponse.Add(new PostResponse(result.Id, result.Title, result.Body, result.User_ID, 
                    result.Topic_ID, result.UpVotes, result.DownVotes, result.Created_At, commentsResponse));
            }
            return postResponse;
        }

        // POST api/<Post>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task NewPost([FromBody] PostRequest post)
        {
            var claim = HttpContext.User.Claims;
            var userClaim = claim.FirstOrDefault(x => x.Type.Equals("userId"));
            int userId = int.Parse(userClaim.Value);

            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Insert", new { post.Title, post.Body, UserId = userId,
                post.TopicId, Upvotes = 0, Downvotes = 0  , CreatedAt = DateTime.Now });
        }

        // PUT api/<Post>
        [HttpPut]
        public Task UpdatePost([FromBody] PostUpdateRequest post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Update", new {post.Id, post.UpVotes, post.DownVotes });
        }

        // DELETE api/<Post>/5
        [HttpDelete("{id}")]
        public Task DeletePost(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Delete", new { Id = id });
        }
    }
}
