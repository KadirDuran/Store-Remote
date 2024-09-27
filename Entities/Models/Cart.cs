using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   
    public class Cart
    {
        public List<CartLine> cartLines { get; set; }
        public Cart() { 
            cartLines = new List<CartLine>();
        }
        public virtual void AddCartLine(Product product,int quantity)
        {
            CartLine? line = cartLines.Where(p => p.Product.productId.Equals(product.productId)).FirstOrDefault();
            if (line is null)
            { 
                cartLines.Add(new CartLine()
                {
                    Product = product,  
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveCartLine(Product product) => cartLines.RemoveAll(p => p.Product.productId.Equals(product.productId));

        public decimal Total() => (decimal)cartLines.Sum(p => p.Quantity * p.Product.productPrice);

        public virtual void Clear() => cartLines.Clear();
    }
   
}
