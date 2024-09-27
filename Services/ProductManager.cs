using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void cProduct(Product product)
        {
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void dProduct(int id)
        {
            Product p = GetOneProduct(id,false);
            if(p is not null)
            {
                _manager.Product.dProduct(p);
                _manager.Save();
            }
            
        }

        public IEnumerable<Product> GetAllProduct(bool trackChanges)
        {
            return _manager.Product.GetAllProduct(trackChanges);
        }

     

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return _manager.Product.GetOneProduct(id,trackChanges);
        }

      

        public void uProduct(Product product)
        {
            var entity = _manager.Product.GetOneProduct(product.productId, true);
            entity.productName = product.productName;
            entity.productPrice= product.productPrice;
            entity.summary = product.summary;
            entity.imageUrl = product.imageUrl;
            entity.categoryId= product.categoryId;
            _manager.Save();
        }
    }
}
