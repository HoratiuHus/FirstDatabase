using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        public static readonly string url = "https://localhost:7249";

        public ActionResult InsertPost(PostRequest post)
        {
            List<PostResponse> postInfo = new List<PostResponse>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync($"{url}/api/Post", post).Result;
                if (response.IsSuccessStatusCode)
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
            }
            return RedirectToAction("Index", "Post");
        }

            public ActionResult Index()
        {
            return View();
        }
    }
}
