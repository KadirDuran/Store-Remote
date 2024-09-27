using Entities.Models;


namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);
      
        void cProduct(Product product);
        void uProduct(Product product);
        void dProduct(int id);
    }
}
