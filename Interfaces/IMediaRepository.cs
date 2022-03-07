using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities;

namespace backend.Interfaces {
    public interface IMediaRepository : IRepository<Media>{
        Task<IEnumerable<Media>> GetByType();
        Task<IEnumerable<Media>> GetByCategory();
        Task<IEnumerable<Media>> GetMediaWithCategoryAndType();
        Task<Media> GetMediaWithCategoryAndTypeById(int id);
        
    }

}