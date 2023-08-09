using DataAccess.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DataAccess.DatabaseAccess;
using Models.Response;
using Models.Request;
using DataAccess.Models;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersAPI.Controllers

{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;

        private readonly ISqlDataAccess _db;

        public UserController(ISqlDataAccess db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Role,user.Role??"User"),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: api/User
        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            var users = await _db.LoadDataAsync<User, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
            List<UserResponse> usersResponse = new List<UserResponse>();
            foreach(var user in users)
            {
                usersResponse.Add(new UserResponse(user.Id, user.Email, user.Username, user.CreatedAt, user.Role));
            }

            return usersResponse;
        }

        // GET api/User/5
        [HttpGet("byId")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<UserResponse?> GetUserByID()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type.Equals("userId"));

            var user =  await _db.LoadDataAsync<User, dynamic>(
            storedProcedure: "dbo.spUser_Get",
            new { Id = userId.Value });
            return new UserResponse(user.First().Id, user.First().Email, user.First().Username, user.First().CreatedAt, user.First().Role);
        }

        // POST api/User
        [HttpPost]
        public Task UserRegister([FromBody] UserRegisterRequest user)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Insert", new { user.Email, user.Username, user.Password, CreatedAt = DateTime.Now, Role = "User"});
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResponse> UserLogin([FromBody] UserLoginRequest userLogin)
        {
            var results = await _db.LoadDataAsync<User, dynamic>(
            storedProcedure: "dbo.spUser_GetByUsername",
            new { Username = userLogin.Username });
            if (results.Count() == 0)
                return new LoginResponse("User not found!", "");
            else
            {
                if (results.First().Password == userLogin.Password)
                {
                    var token = Generate(results.First());
                    return new LoginResponse("Logged in!", token);
                }
                else
                {
                    return new LoginResponse("Wrong password!", "");
                }
            }
            throw new Exception();
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public Task UserDelete(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Delete", new { Id = id });
        }
    }
}
