
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewCompenent:ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public ProductSummaryViewCompenent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }


        public string Invoke()
        {
            return _serviceManager.ProductService.GetAllProduct(false).Count().ToString();
        }
    }
}
