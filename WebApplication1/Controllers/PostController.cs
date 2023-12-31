﻿using DataAccess.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.Response;
using NuGet.Common;
using System;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
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
                var token = Request.Cookies["token"];
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",
                token);
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
