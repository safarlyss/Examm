using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Utilities.Extensions;
using WebApplication1.ViewModels;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public TeamController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index(int page=1,int take=1)
        {
            var teams   =await _context.Teams.Skip((page-1)*take).Take(take).ToListAsync();
            PaginateVM<Team> paginateVM = new PaginateVM<Team>()
            {
                PageCount = PageCount(take),
                CurrentPage = page,
                Take = take,
                Items = teams
            };
            return View(paginateVM);
        }
        private int PageCount(int take)
        {
            int count=_context.Teams.Count();
            return (int)Math.Ceiling((double)count / take);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Team team)
        {
            if(!ModelState.IsValid) return View();  
            if(!team.File.CheckFileType("image"))
            {
                ModelState.AddModelError("File", "File must be image format");
                return View();
            }
            if(team.File.CheckFileSize(2000))
            {
                ModelState.AddModelError("File", "File size  must be less than 2000kb");
                return View();
            }
            team.Image = await team.File.SaveFileAsync(_environment.WebRootPath, "assets/img/team");
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result=await _context.Teams.FirstOrDefaultAsync(x=> x.Id == id);    
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Team team)
        {
            if (!ModelState.IsValid) return View();
            Team exist = await _context.Teams.FirstOrDefaultAsync(x => x.Id == team.Id);
            if(team.File!=null)
            {
                if (!team.File.CheckFileType("image"))
                {
                    ModelState.AddModelError("File", "File must be image format");
                    return View();
                }
                if (team.File.CheckFileSize(2000))
                {
                    ModelState.AddModelError("File", "File size  must be less than 2000kb");
                    return View();
                }
             exist.Image.DeleteFile(_environment.WebRootPath, "assets/img/team");
           exist.Image = await team.File.SaveFileAsync(_environment.WebRootPath, "assets/img/team");

            }
            
            exist.FullName = team.FullName;
            exist.Profession= team.Profession;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return View();
            Team exist = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if(exist==null) return NotFound();
             exist.Image.DeleteFile(_environment.WebRootPath, "assets/img/team");
             _context.Teams.Remove(exist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
