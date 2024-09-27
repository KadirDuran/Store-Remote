using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Entities.Models;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var model = _serviceManager.ProductService.GetAllProduct(false);
            return View(model);

        }
        public IActionResult Get(int id)
        {
            var model = _serviceManager.ProductService.GetOneProduct(id,false);
            return View(model);

        }
    }
}
