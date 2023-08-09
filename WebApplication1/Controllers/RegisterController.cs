using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        public static readonly string url = "https://localhost:7249";



        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateUser(UserRegisterRequest user)
        {
            IEnumerable<UserResponse> registerInfo = new List<UserResponse>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync($"{url}/api/User", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Register");
        }

    }
}
