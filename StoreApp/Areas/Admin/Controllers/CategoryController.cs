using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _services;

        public CategoryController(IServiceManager services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            ViewBag.Category = new SelectList(_services.CategoryService.GetAllCategory(false), "categoryId", "categoryName",1);
            return View();
             
        }
    }
}
