using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingsController : Controller
    {
        private readonly AppDbContext _context;

        public SettingsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Settings.ToList());
        }
        public async Task <IActionResult> Edit(int id)
        {
            var result = await _context.Settings.FirstOrDefaultAsync(x => x.Id == id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Settings settings)
        {
            if (!ModelState.IsValid) return View();
            Settings exist = await _context.Settings.FirstOrDefaultAsync(x => x.Id == settings.Id);
            exist.Key = settings.Key;
            exist.Value = settings.Value;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
