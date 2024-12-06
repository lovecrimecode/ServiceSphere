using Microsoft.AspNetCore.Mvc;
using ServiceSphere.Web.Models;
using System.Diagnostics;

namespace ServiceSphere.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        /*public IActionResult MyActionNameIsOneThing()
        {
            // return View();

            return View("ButMyViewNameIsOther");
        }*/
/*
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
