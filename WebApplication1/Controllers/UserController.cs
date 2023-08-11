using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Policy;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public static readonly string url = "https://localhost:7249";

        public async Task<UserResponse> GetUser(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",
                token);
                HttpResponseMessage response = await client.GetAsync($"{url}/api/User/byId");

                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<UserResponse>();
                    if (user != null)
                        return user;
                }
            }
            throw new Exception();

        }
        public ActionResult Index()
        {
            var token = Request.Cookies["token"];
            if (token != null)
            {
                return View(GetUser(token).Result);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
