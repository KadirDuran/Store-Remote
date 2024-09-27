

using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProduct(bool trackChanges);

        Product? GetOneProduct(int id, bool trackChanges);

        void CreateProduct(Product product);
        void dProduct(Product p);
    }
}
