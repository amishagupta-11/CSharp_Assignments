using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewDataSample.Models;

namespace ViewDataSample.Controllers
{
    public class HomeController : Controller
    {
       public ViewResult Index([FromQuery]int id)
       {
            MovieDetails movieDetails=new MovieDetails();
            IEnumerable<Movies> moviesDetailsObj = movieDetails.GetDetailsById(id);
            ViewData["Movies"]=moviesDetailsObj;
            ViewData["Header"]="Movie Details";
            return View(moviesDetailsObj);
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}