using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Contexts;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Implementations {
    public class MediaRepository : Repository<Media>, IMediaRepository
    {
        private readonly Context _context;
        private readonly DbSet<Media> _medias;

        public MediaRepository(Context context):base(context) {
            _context = context;
            _medias = context.Medias;
        }
        public Task<IEnumerable<Media>> GetByCategory()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Media>> GetByType()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Media>> GetMediaWithCategoryAndType()
        {
            return await _medias.Include(m=>m.Category).Include(m=>m.TypeMedia).ToListAsync();
        }

        public async Task<Media> GetMediaWithCategoryAndTypeById(int id)
        {
        return await _medias.Include(m=>m.Category).Include(m=>m.TypeMedia).Where(m=>m.Id == id).FirstOrDefaultAsync();
          
        }
    }
}