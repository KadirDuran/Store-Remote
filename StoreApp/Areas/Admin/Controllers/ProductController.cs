using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IServiceManager _services;

        public ProductController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var model = _services.ProductService.GetAllProduct(false);
            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.Categories =
                new SelectList(_services.CategoryService.GetAllCategory(false),
                "categoryId", "categoryName",1);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Product product, IFormFile file)
        {
            if (_services.ProductService.GetAllProduct(false).Any(c=>c.productName.Equals(product.productName)))
            {
                ModelState.AddModelError("", "Bu ürün daha önceden eklenmiş!");
            }
            if(ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot","images",file.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                product.imageUrl = String.Concat("/images/",file.FileName);
                _services.ProductService.cProduct(product);
                return RedirectToAction("Index");
            }else { return View(); }
            
        }
        public IActionResult Update(int id)
        {
            ViewBag.uCategory = new SelectList(_services.CategoryService.GetAllCategory(false),"categoryId", "categoryName");
          
                return View(_services.ProductService.GetOneProduct(id, false));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] Product product, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    product.imageUrl = String.Concat("/images/", file.FileName);
                }
                else
                {
                    product.imageUrl = _services.ProductService.GetOneProduct(product.productId,false).imageUrl;

                }
                _services.ProductService.uProduct(product);
                return RedirectToAction("Index");

            }
            else { return View(); }

        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {

            _services.ProductService.dProduct(id);
            return RedirectToAction("Index");
           
            
        }
    }
}
