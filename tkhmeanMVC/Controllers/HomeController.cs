using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using tkhmeanMVC.Data;
using tkhmeanMVC.Data.Helpers;
using tkhmeanMVC.Models;

namespace tkhmeanMVC.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost()]
        public Task<Game> Login([FromBody]string username)
        {
            
            return Task.Run(() =>
            {
                try
                {

                    User user = new User();
                    user.name = username;
                    return GameManager.addUserToGame(user);


                }
                catch (Exception)
                {

                    return null;

                }


            });

        }

        // the rest is already there from the MVC example by visual studio
        public IActionResult Index()
        {
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
