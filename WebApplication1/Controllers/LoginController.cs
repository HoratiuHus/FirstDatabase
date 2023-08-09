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

        //[HttpPost]
        //public ActionResult WriteCookie()
        //{
        //    //Create a Cookie with a suitable Key.
        //    HttpCookie nameCookie = new HttpCookie("Cookie");

        //    //Set the Cookie value.
        //    nameCookie.Values["Name"] = Request.Form["name"];

        //    //Set the Expiry date.
        //    nameCookie.Expires = DateTime.Now.AddDays(30);

        //    //Add the Cookie to Browser.
        //    Response.Cookies.Add(nameCookie);

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult ReadCookie()
        //{
        //    //Fetch the Cookie using its Key.
        //    HttpCookie nameCookie = Request.Cookies["Name"];

        //    //If Cookie exists fetch its value.
        //    string name = nameCookie != null ? nameCookie.Value.Split('=')[1] : "undefined";

        //    TempData["Message"] = name;

        //    return RedirectToAction("Index");
        //}
    }
}

