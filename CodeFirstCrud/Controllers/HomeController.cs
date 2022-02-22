
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstCrud.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        //private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        [Authorize]
        public IActionResult ConfidentialData()
         {
            return View();
         }

        public ActionResult<IEnumerable<string>> Get(int id)
        {
            _logger.LogInformation("Start : Getting item details for {ID}", id);

            List<string> list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");

            _logger.LogInformation($"Completed : Item details are { string.Join(", ", list) }");
            return list;
        }


    }
}
