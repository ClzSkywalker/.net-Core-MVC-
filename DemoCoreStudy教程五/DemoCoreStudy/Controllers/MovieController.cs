using DemoCoreStudy.Models;
using DemoCoreStudy.Serivce;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoCoreStudy.Controllers
{
    public class MovieController:Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMovieService _movieService;

        public MovieController(ICinemaService cinemaService,IMovieService movieService)
        {
            _cinemaService = cinemaService;
            _movieService = movieService;
        }

        //在特定电影ID下显示电影名
        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema =await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}电影院上映的有：";
            return View(await _movieService.GetByCinemaAsync(cinemaId));
        }

        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie {CinemaId = cinemaId});
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }

            //这里返回上面的Index时，发现有参数所以添加下参数
            return RedirectToAction("Index", new {cinemaId = movie.Id});
        }
    }
}
