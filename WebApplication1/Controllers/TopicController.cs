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
    public class TopicController : Controller
    {
        public static readonly string url = "https://localhost:7249";

        private async Task<IEnumerable<TopicResponse>> GetAllTopics()
        {
            IEnumerable<TopicResponse> topicsInfo = new List<TopicResponse>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync($"{url}/api/Topic");
                if (response.IsSuccessStatusCode)
                {
                    var topics = await response.Content.ReadFromJsonAsync<IEnumerable<TopicResponse>>();
                    if (topics != null)
                        return topics.ToList();
                }
            }
            return topicsInfo;
        }

        [HttpGet]
        public ActionResult UpdateTopicVotes(TopicUpdateRequest votes)
        {
            IEnumerable<TopicUpdateRequest> votesInfo = new List<TopicUpdateRequest>();
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PutAsJsonAsync($"{url}/api/Topic", votes).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Topic");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        //public IActionResult UpVote(int upVotes = 0)
        //{
        //    return ;
        //}

        public IActionResult Index(int topicId = 0)
        {
            var response = GetAllTopics().Result;
            return View(response);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
