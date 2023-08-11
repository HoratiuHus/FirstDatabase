using Microsoft.AspNetCore.Mvc;
using Models.Response;
using System.Net.Http.Headers;
using Models.Request;
using System.Text.Json;
using System.Net;
using WebApplication1.Models;
using NuGet.Packaging.Signing;
using System.Diagnostics;
using System.Net.Http.Json;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        public static readonly string url = "https://localhost:7249";

        // GET: LoginController
        [HttpPost]
        public ActionResult UserLogin(UserLoginRequest user)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync($"{url}/api/User/login", user).Result;
                if (response.IsSuccessStatusCode)
                {
                    var login =  response.Content.ReadFromJsonAsync<LoginResponse>().Result;
                    if (login != null)
                    {
                        if(login.Message == "User not found!")
                        {
                            return RedirectToAction("Index", "Register");
                        }
                        if (login.Message == "Logged in!")
                        {
                            Response.Cookies.Append("token", login.Token,
                            new CookieOptions() { Expires = DateTime.Now.AddDays(1) });
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }
            }
            throw new Exception();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}

