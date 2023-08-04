using DataAccess.DatabaseAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ISqlDataAccess _db;

        public CommentController(ISqlDataAccess db)
        {
            _db = db;
        }

        // POST api/<Comment>
        [HttpPost()]
        public Task Post([FromBody] CommentRequest comment)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Insert", new { comment.Comment, comment.UserId, comment.PostId, comment.TopicId });
        }

        // DELETE api/<Comment>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Delete", new { Id = id });
        }


    }
}
