using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EvaRepro.Controllers
{
    public class HomeController : Controller
    {
        private const string MY_URL = "http://www.google.com";
        private readonly Task<string> task;

        public HomeController() { task = DownloadAsync(); }

        public ActionResult Index()
        {
            return View();
        }

        private async Task<string> DownloadAsync()
        {
            using (WebClient myWebClient = new WebClient())
                return await myWebClient.DownloadStringTaskAsync(MY_URL)
                                        .ConfigureAwait(false);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}