using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using NuGet.Common;
using System.Net.Http.Headers;
using System;
using System.Security.Policy;

namespace WebApplication1.Controllers
{
    public class CommentController : Controller
    {
        public static readonly string url = "https://localhost:7249";
        public ActionResult InsertComment(CommentRequest comm)
        {
            var topicId = ViewBag.TopicId;

            List<CommentResponse> commentInfo = new List<CommentResponse>();
            using (HttpClient client = new HttpClient())
            {
                var token = Request.Cookies["token"];
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",
                token);
                HttpResponseMessage response = client.PostAsJsonAsync($"{url}/api/Comment", comm).Result;
                if (response.IsSuccessStatusCode)
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Home");
                    }
            }
            return RedirectToAction("Index", "Comment");
        }
        public IActionResult Index(int topicId, int postId)
        {
            return View(new CommentRequest { PostId = postId, TopicId = topicId});
        }
    }
}
