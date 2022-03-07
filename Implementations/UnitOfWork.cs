using System.Threading.Tasks;
using backend.Contexts;
using backend.Interfaces;

namespace backend.Implementations {
    public class UnitOfWork : IUnitOfWork
    {
        public IMediaRepository MediaRepository{get;}

        public ICategoryRepository CategoryRepository {get;}

        public ItypeMediaRepository TypeMediaRepository {get;}

        private readonly Context _context;

        public UnitOfWork(
        Context context, 
        ICategoryRepository categoryRepository,
        IMediaRepository mediaRepository,
        ItypeMediaRepository typeMediaRepository
        ){
            _context = context;
            MediaRepository = mediaRepository;
            CategoryRepository = categoryRepository;
            TypeMediaRepository = typeMediaRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}