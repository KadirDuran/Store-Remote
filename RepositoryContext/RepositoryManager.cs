using Repositories.Contracts;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly RepositoryContext _context;

        public RepositoryManager(IProductRepository repository,RepositoryContext _c,ICategoryRepository categoryRepository )
        {
            _context = _c;
            _repository = repository;
            _categoryRepository = categoryRepository;
          
        }
        public IProductRepository Product => _repository;

        ICategoryRepository IRepositoryManager.Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
