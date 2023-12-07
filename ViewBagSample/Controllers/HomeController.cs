using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewBagSample.Models;

namespace ViewBagSample.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(int id)
        {
            MovieDetails movieDetails = new MovieDetails();
            IEnumerable<Movies> moviesDetailsObj = movieDetails.GetDetailsById(id);
            ViewBag.Movies= moviesDetailsObj;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}