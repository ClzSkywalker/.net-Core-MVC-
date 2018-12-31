using DemoCoreStudy.Models;
using DemoCoreStudy.Serivce;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DemoCoreStudy.Controllers
{
    public class HomeController:Controller
    {
        //搭建本地实例
        private readonly ICinemaService _cinemaService;

        public HomeController(ICinemaService cinemaService)
        {
            //需要Service里面的数据，数据从ICinemaService请求，CinemaMemoryService获取并返回实例
            _cinemaService = cinemaService;
        }

        //获取全部电影院信息
        public async Task<IActionResult> Index()
        {
            //标题
            ViewBag.Title = "电影院列表";
            return View(await _cinemaService.GetllAllAsync());
        }

        //添加电影院信息
        public IActionResult add()
        {
            ViewBag.Title = "添加电影院";
            return View(_cinemaService.AddAsync(new Cinema()));
        }

        [HttpPost]//添加，不然默认是[HttpGet](查询),上面得到就是
        public async Task<IActionResult> Add(Cinema model)
        {
            //model的验证
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }
            //跳转回HomeController下面的Action
            return RedirectToAction("Index");
        }
    }
}
