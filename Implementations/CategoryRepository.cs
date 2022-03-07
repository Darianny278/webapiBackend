using System.Threading.Tasks;
using backend.Contexts;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Implementations {
    public class CategoryRepository: Repository<Category>, ICategoryRepository {

         private readonly Context _context;
        private readonly DbSet<Category> _categories;

        public CategoryRepository( Context context):base(context) {
            _context = context;
            _categories = context.Categories;
        }
        public Task<Category> GetByName()
        {
            throw new System.NotImplementedException();
        }
    }
}