using DataAccess.DatabaseAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public Task NewComment([FromBody] CommentRequest comment)
        {
            var claim = HttpContext.User.Claims;
            var userClaim = claim.FirstOrDefault(x => x.Type.Equals("userId"));
            int userId = int.Parse(userClaim.Value);

            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Insert", new { comment.Comment, UserId = userId, comment.PostId, comment.TopicId });
        }

        // DELETE api/<Comment>/5
        [HttpDelete("{id}")]
        public Task DeleteComment(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Delete", new { Id = id });
        }


    }
}
