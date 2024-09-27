using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class CategoryMenuViewCompenent:ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoryMenuViewCompenent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        public IViewComponentResult Invoke()
        {
            return View(_serviceManager.CategoryService.GetAllCategory(false));
        }
    }
}
