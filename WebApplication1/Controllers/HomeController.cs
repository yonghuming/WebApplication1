using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }




        //public IActionResult Index()
        //{

        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            // 在A控制器访问B模型的方法,
            // 需要细化
            //不同门类的显示
            //根据角色不同显示不同的菜单
            //
            // Todo: 完善用户认证,甄别用户是否登录
            // 链接分类

            ViewData["Message"] = "Your application description page.";

            return View(await _context.Urls.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        

        public async Task<IActionResult> Ss()
        {
            // 在A控制器访问B模型的方法,
            // 需要细化
            ViewData["Message"] = "Your application description page.";

            return View(await _context.Urls.ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
