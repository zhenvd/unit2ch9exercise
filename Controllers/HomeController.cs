using HelloASPDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("/helloworld/")]
        public IActionResult Index()
        {

            string openingForm = "<form method='post' action='/hello/world'>";
            string language = Language();
            string openingInput = "<input type='text' name='name' value='Enter name here'/>";
            string submitInput = "<input type='submit' value = 'Greet Me!' />";
            string closingForm = "</form>";
            string html = openingForm + openingInput + language + submitInput + closingForm;
            return Content(html, "text/html");
            //return View();
        }
        [HttpPost]
        [Route("/hello/world/")]
        public IActionResult Display(string name, string value)
        {
            return Content(CreateMessage(name, value), "text/html");
        }
        public static string CreateMessage(string name, string value)
        {
            string output = "";
            switch (value)
            {
                case "English":
                    output = "Hello!";
                    break;
                case "Spanish":
                    output = "Hola!";
                    break;
                case "German":
                    output = "Hallo!";
                    break;
                case "Italian":
                    output = "Ciao!";
                    break;
                case "French":
                    output = "Bonjour!";
                    break;
                    //default:
                    //    output = "Hello!";
                    //    break;
            }
            return output + name;
        }

        public string Language()
        {
            string opening = "<select name = 'value'>";
            string first = "<option value='English'>English</option>";
            string second = "<option value='Spanish'>Spanish</option>";
            string third = "<option value='French'>French</option>";
            string fourth = "<option value='German'>German</option>";
            string fifth = "<option value='Italian'>Italian</option>";
            string closing = "</select>";
            return opening + first + second + third + fourth + fifth + closing;
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
