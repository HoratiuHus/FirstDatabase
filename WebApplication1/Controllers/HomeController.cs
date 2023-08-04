using Microsoft.AspNetCore.Mvc;
using Models.Response;
using System.Net.Http.Headers;
using Models.Request;
using System.Text.Json;
using System.Net;
using WebApplication1.Models;
using NuGet.Packaging.Signing;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public static readonly string url = "https://localhost:7249";

        private async Task<IEnumerable<PostResponse>> GetAllPosts()
        {
            IEnumerable<PostResponse> postsInfo = new List<PostResponse>();
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"{url}/api/Post");
                    if (response.IsSuccessStatusCode)
                    {
                        var posts = await response.Content.ReadFromJsonAsync<IEnumerable<PostResponse>>();
                        if (posts != null)
                            return posts.ToList();
                    }
                }
            return postsInfo;
        }

        public IActionResult Index()
        {
            var response = GetAllPosts().Result;
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}