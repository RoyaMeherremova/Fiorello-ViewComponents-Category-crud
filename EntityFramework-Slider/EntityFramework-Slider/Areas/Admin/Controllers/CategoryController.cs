using EntityFramework_Slider.Data;
using EntityFramework_Slider.Models;
using EntityFramework_Slider.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework_Slider.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly AppDbContext _context;
        public CategoryController(ICategoryService categoryService,
                                  AppDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()    /*async-elemirik cunku data gelmir databazadan*/
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)    /*async-elemirik cunku data gelmir databazadan*/
        {
            await _context.Categories.AddAsync(category);  //gelen Category tipden categorini save ele Databazadaya
            await _context.SaveChangesAsync();  //ve yaddasda saxla yeni dataynan
            return RedirectToAction(nameof(Index));
        }
    }
}
