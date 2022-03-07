using System.Threading.Tasks;
using backend.Entities;

namespace backend.Interfaces {
    public interface ICategoryRepository : IRepository<Category> {
        Task<Category> GetByName();
    }
}