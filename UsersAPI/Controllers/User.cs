using DataAccess.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DatabaseAccess;
using Models.Response;
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
            var users = await _db.LoadDataAsync<DataAccess.Models.User, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
