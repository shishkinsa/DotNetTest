using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TNEStudentScoreClient.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using TNEStudentScoreModels.ViewModels;

namespace TNEStudentScoreClient.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _config;
        string apiEndpoint = "";
        public HomeController(IConfiguration iConfig)
        {
            _config = iConfig;
            apiEndpoint = _config.GetSection("ApiEndpoint").Value;
        }
        public IActionResult Index()
        {
            ViewBag.SwaggerURL = String.Format("{0}/swagger", apiEndpoint);

            return View();
        }

        public async Task<ActionResult> LoadStudentsMVC(int year = 2018, int avg = 3)
        {
            List<StudentViewModel> listStudents = new List<StudentViewModel>();
            var apiEndpoint = _config.GetSection("ApiEndpoint").Value;
            var apiModel = "api/StudentScores";
            var queryUrl = String.Format("{0}/{1}?year={2}&avg={3}", apiEndpoint, apiModel, year, avg);

            using (HttpClient client = new HttpClient())
            { 
                try
                {
                    HttpResponseMessage response = await client.GetAsync(queryUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    listStudents = JsonConvert.DeserializeObject<List<StudentViewModel>>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    // Log exception...
                }
            }
            ViewBag.SwaggerURL = String.Format("{0}/swagger", apiEndpoint);
            return View(listStudents);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
