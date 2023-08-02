using DataAccess.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DatabaseAccess;
using Models.Response;
using Models.Request;
using DataAccess.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersAPI.Controllers

{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ISqlDataAccess _db;

        public UserController(ISqlDataAccess db)
        {
            _db = db;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            var users = await _db.LoadDataAsync<User, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
            List<UserResponse> usersResponse = new List<UserResponse>();
            foreach(var user in users)
            {
                usersResponse.Add(new UserResponse(user.Id, user.Email, user.Username, user.CreatedAt 
                ));
            }

            return usersResponse;
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<UserResponse?> GetUserByID(int id, UserResponse user)
        {
            var results =  await _db.LoadDataAsync<User, dynamic>(
            storedProcedure: "dbo.spUser_Get",
            new { Id = id });
            return new UserResponse(user.Id, user.Email, user.Username, user.CreatedAt);
        }

        // POST api/User
        [HttpPost]
        public Task Post([FromBody] UserRequest user)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Insert", new { user.Email, user.Username, user.Password, CreatedAt = DateTime.Now});
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] UserRequest user)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Update", new { user.Email, user.Username, user.Password });
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Delete", new { Id = id });
        }
    }
}
