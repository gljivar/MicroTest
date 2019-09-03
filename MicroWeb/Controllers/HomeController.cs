using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroWeb.Models;
using Newtonsoft.Json;

namespace MicroWeb.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("Micro");
        }

        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync("/api/values");
            var content = await response.Content.ReadAsStringAsync();

            ViewData["Values"] = JsonConvert.DeserializeObject<string>(content);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
