using Microsoft.AspNetCore.Mvc;
using WebApplication1.DAL;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Aboutus=_context.Aboutus.ToList(),
                FAQs=_context.FAQs.ToList(),
                OurServices=_context.OurServices.ToList(),
                Portfolio=_context.Portfolio.ToList(),
                Sliders=_context.Sliders.ToList(),
                Team=_context.Teams.Take(4).ToList()

            };
            return View(homeVM);
        }
    }
}
