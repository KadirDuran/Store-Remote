using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        public readonly IServiceManager serviceManager;
      public Cart cart { get; set; }

        public CartModel(IServiceManager _serviceManager, Cart cartService)
        {
            serviceManager = _serviceManager;
            cart = cartService;
        }


        public string returnUrls = "";
        public void OnGet()
        {
            returnUrls = returnUrls ?? "/Product";
            
        }
       
        public IActionResult OnPost(int productId, string returnUrl)
        {

            Product? product = serviceManager.ProductService.GetOneProduct(productId, false);
            
            if(product is not null)
            {
                cart.AddCartLine(product, 1);
                
            }
            return RedirectToPage(new { returnUrls=returnUrl }) ;
        }
        public IActionResult OnPostRemoveSS(int id, string returnUrl)
        {
           
                cart.RemoveCartLine(cart.cartLines.First(cl => cl.Product.productId.Equals(id)).Product);
             
            return Page(); 
        }


    }
}
