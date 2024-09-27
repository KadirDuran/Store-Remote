

using Entities.Models;
using Repositories.Contracts;
using Repositories.Models;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.productId.Equals(id),trackChanges);
        }

        public IQueryable<Product> GetAllProduct(bool trackChanges) => GetAll(trackChanges);

        public void CreateProduct(Product product) => Create(product);

        public void dProduct(Product p)=>deleteProduct(p);
    }
}
