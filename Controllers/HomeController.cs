using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegularExpressionDoS.Models;
using RegularExpressionDoS.Repository;

namespace RegularExpressionDoS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Requirement RQ-103: Users should be able to search multiple words
        // Example 1: allan poe
        // Example 2: powerful world
        public IActionResult Search(Query query)
        {
            if (String.IsNullOrEmpty(query.Search))
            {
                return View("Index");
            }

            if(!Regex.IsMatch(query.Search, @"^([a-zA-Z0-9]+ ?)+$"))
            {
                return RedirectToAction("Error");
            }

            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Error");
            //}
            ViewBag.Search = query.Search.Trim(); ;
            QuoteRepository repository = new QuoteRepository();
            return View("Index", repository.Search(query.Search.Trim()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
