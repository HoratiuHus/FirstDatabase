using Microsoft.AspNetCore.Mvc;
using Models.Response;
using System;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public static readonly string url = "https://localhost:7249";

        public async Task<IEnumerable<UserResponse>> GetUser(int userId)
        {
            IEnumerable<UserResponse> userInfo = new List<UserResponse>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"{url}/api/User/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<IEnumerable<UserResponse>>();
                    if (user != null)
                        return user.ToList();
                }
            }
            return userInfo;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
