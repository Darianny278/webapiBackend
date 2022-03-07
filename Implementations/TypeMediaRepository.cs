using backend.Contexts;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Implementations{
    public class TypeMediaRepository: Repository<TypeMedia>, ItypeMediaRepository{
        private readonly Context _context;
        private readonly DbSet<TypeMedia> _typeMedias;

        public TypeMediaRepository(Context context) : base(context)
        {
            _context = context;
            _typeMedias = context.TypeMedias;
        }
    }
}